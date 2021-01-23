    SlidingExpiration = true, 
    ExpireTimeSpan = TimeSpan.FromMinutes(30)
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString(url.Action("LogIn","Auth")),
            Provider = new CookieAuthenticationProvider
            {
                // Enables the application to validate the security stamp when the user logs in.
                // This is a security feature which is used when you change a password or add an external login to your account.  
                OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, User>(
                    validateInterval: TimeSpan.FromMinutes(30),
                    regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
            },
            CookieName = "MyApplication", 
            SlidingExpiration = true, 
            ExpireTimeSpan = TimeSpan.FromMinutes(30)
        });
