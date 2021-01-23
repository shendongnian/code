    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        //Replace the Authentication Scheme with MyAuthScheme
        AuthenticationScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme,
        AutomaticAuthenticate = true,
        ExpireTimeSpan = TimeSpan.FromMinutes(60)
    });
