    public void Configuration(IAppBuilder app)
    {
        //Some Code
        app.UseCookieAuthentication(GetCookieAuthenticationOptions());
        //Some Code
    }
    private static CookieAuthenticationOptions GetCookieAuthenticationOptions()
    {
        var options  = new CookieAuthenticationOptions();
        {
            CookieName = "AuthCookie",  //Some cookie settings here
        };
        var provider = (CookieAuthenticationProvider)options.Provider;
        provider.OnResponseSignIn = (context) => 
        {
            context.Properties.IsPersistent = true;
            context.Properties.ExpiresUtc = DateTimeOffset.UtcNow.AddHours(24);
        };
        return options;
    }
