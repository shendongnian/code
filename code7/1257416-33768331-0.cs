    const string applicationCookieName = ".AspNet.ApplicationCookie";
    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        LoginPath = new PathString("/"),
        CookieName = applicationCookieName,
        Provider = new CookieAuthenticationProvider
        {
            // Called *after* user is signed in -- the cookie
            // we want has been set at this point.
            OnResponseSignedIn = context =>
            {
                var cookieHeader = context.Response.Headers["Set-Cookie"];
                var cookies = context.Response.Headers.GetCommaSeparatedValues("Set-Cookie");
                var cookieValue = "";
                foreach (var cookie in cookies)
                {
                    var cookieKeyIndex = cookie.IndexOf(applicationCookieName);
                    if (cookieKeyIndex != -1)
                    {
                        // Add extra character for '='
                        cookieValue = cookie.Substring(applicationCookieName.Length + 1);
                        break;
                    }
                }
                // Do what you need with cookieValue
            }
        }
    });
