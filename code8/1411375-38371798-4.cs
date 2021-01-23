     public void Configuration(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Home/Login"),
                Provider = new CookieAuthenticationProvider(),
                CookieName = "ApplicationCookie",
                CookieHttpOnly = true,
                ExpireTimeSpan = TimeSpan.FromHours(1),
            });
            app.UseWsFederationAuthentication(
                new WsFederationAuthenticationOptions
                {
                    Wtrealm = realm,
                    MetadataAddress = adfsMetadata
                });
        }
