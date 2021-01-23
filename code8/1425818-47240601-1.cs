    services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.LogoutPath = new PathString("/Account/Logout");
        options.Events.OnRedirectToLogin = context =>
        {
            if (context.Request.Path.StartsWithSegments("/api")
                && context.Response.StatusCode == StatusCodes.Status200OK)
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return Task.FromResult<object>(null);
            }
            context.Response.Redirect(context.RedirectUri);
            return Task.FromResult<object>(null);
        };
    });
