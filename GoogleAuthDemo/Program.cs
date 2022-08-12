using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options => 
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme
    )
    .AddCookie(options => 
        options.LoginPath = "/account/google-login"
    )
    .AddGoogle(options =>
    {
        options.ClientId = "894907939345-mco4do4mttaiojmebv8ptvcslfv1ofun.apps.googleusercontent.com";
        options.ClientSecret = "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";
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
