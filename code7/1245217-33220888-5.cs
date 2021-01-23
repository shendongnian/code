    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        // other stuff
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        LoginPath = new PathString("/Account/Login"),
        Provider = new CookieAuthenticationProvider
        {
            OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                validateInterval: TimeSpan.FromMinutes(0), // <-- Note the timer is set for zero
                regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
        }
    }); 
