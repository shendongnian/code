    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        CookieName = "SecurityCookie",
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        LoginPath = new PathString("/Authentication/Login"),
        CookieSecure = CookieSecureOption.SameAsRequest,
        CookieHttpOnly = true,
        AuthenticationMode = AuthenticationMode.Active,
        Provider = cookieProvider, // instance of Microsoft.Owin.Security.Cookies.CookieAuthenticationProvider
        LogoutPath = new PathString("/Authentication/LogOff"),
        SlidingExpiration = true,
        ExpireTimeSpan = TimeSpan.FromDays(days),
    });
