    app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login"),
                    ExpireTimeSpan = sessionSection.Timeout.Add(sessionSection.Timeout),
                    SlidingExpiration = true,
                    Provider = new CookieAuthenticationProvider()
                });
