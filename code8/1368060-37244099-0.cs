    app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        LoginPath = new PathString("/login"),
        Provider = new CookieAuthenticationProvider
        {
            OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                validateInterval: TimeSpan.FromMinutes(30),
                regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
        },
        TicketDataFormat = new SecureDataFormat<AuthenticationTicket>(
            DataSerializers.Ticket,
            new AesDataProtectorProvider("myAuthKey"),
            TextEncodings.Base64)
    });
    app.Use(typeof(AuthMiddleware), app, new AuthOptions());
