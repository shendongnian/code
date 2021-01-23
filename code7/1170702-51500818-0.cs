    //app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
            CookieAuthenticationOptions cookieAuthenticationOptions = new CookieAuthenticationOptions();
            cookieAuthenticationOptions.AuthenticationType = DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie;
            cookieAuthenticationOptions.AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Passive;
            cookieAuthenticationOptions.CookieName = ".AspNet." + DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie;
            cookieAuthenticationOptions.ExpireTimeSpan = TimeSpan.FromDays(365);
            cookieAuthenticationOptions.SlidingExpiration = false;
            CookieAuthenticationExtensions.UseCookieAuthentication(app, cookieAuthenticationOptions);
