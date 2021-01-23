    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        Provider = new CookieAuthenticationProvider
        {
            // Enables the application to validate the security stamp when the user logs in.
            // This is a security feature which is used when you change a password or add an external login to your account.             
            OnValidateIdentity = SecurityStampValidator
                    .OnValidateIdentity<UserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromSeconds(0),
                        regenerateIdentityCallback: (manager, user) => user.GenerateUserIdentityAsync(manager))
        }            
    );
