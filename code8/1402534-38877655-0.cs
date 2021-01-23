    services.Configure<IdentityOptions>(options =>
    {
            options.Cookies.ApplicationCookie.AutomaticAuthenticate = false;
            options.Cookies.ApplicationCookie.AutomaticChallenge = false;
            options.Cookies.ApplicationCookie.LoginPath = PathString.Empty;
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = true;
    });
