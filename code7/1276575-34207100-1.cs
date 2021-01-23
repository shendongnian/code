    Provider = new CookieAuthenticationProvider
    {
        // Enables the application to validate the security stamp when the user logs in.
        // This is a security feature which is used when you change a password or add an external login to your account.  
        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
            validateInterval: TimeSpan.FromMinutes(30),
            regenerateIdentity: (manager, user) => manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie))
    }
