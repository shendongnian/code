    app.UseCookieAuthentication(options =>
            {
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true;
         
                options.LoginPath = new PathString("/Account/Login");
                options.LogoutPath = new PathString("/Account/Logout");
                options.AccessDeniedPath = new PathString("/Account/AccessDenied");
                options.AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.CookieSecure = CookieSecureOption.SameAsRequest;
                options.CookieHttpOnly = true;
            });
