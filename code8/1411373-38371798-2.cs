    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        AuthenticationType = "ApplicationCookie",
        LoginPath = new PathString("/Login"),
        Provider = new CookieAuthenticationProvider(),
        CookieName = "ApplicationCookie",
        CookieHttpOnly = true,
        ExpireTimeSpan = ConfigurationContext.Current.GetCookieLifeLength(),
    });
