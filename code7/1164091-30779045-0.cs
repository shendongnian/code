    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        CookieSecure = CookieSecureOption.SameAsRequest,
        CookieName = "CustomCookieName",
        LoginPath = new PathString("/Account/Login"),
        Provider = new CookieAuthenticationProvider
        {
            OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, User>(
                validateInterval: TimeSpan.FromMinutes(30),
                regenerateIdentity: (manager, user) => Some.Custom.Identity.Helper.GenerateUserIdentityHelperAsync(user, manager)) // This helper method returns ClaimsIdentity for the user
        }
    });
    app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
