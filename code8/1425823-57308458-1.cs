    services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<IdentityContext>()
        .AddDefaultTokenProviders()
        .AddRoles<IdentityRole>();
    
    services.ConfigureApplicationCookie(options =>
    {
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.Headers["Location"] = context.RedirectUri;
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        };
    });
