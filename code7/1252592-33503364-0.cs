    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        LoginPath = new PathString("/Account/Login"),
        Provider = new CookieAuthenticationProvider
        {
            OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserManager, ApplicationUser>(
                validateInterval: TimeSpan.FromMinutes(0),
                regenerateIdentity: (manager, user) => manager.GenerateUserIdentityAsync(user))
        },
        CookieName = "myAuthCookie",
    });
