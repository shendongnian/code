    [assembly: OwinStartup(typeof(YOUR_APP.Startup))]    
    namespace YOUR_APP
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = "ApplicationCookie",
                    LoginPath = new PathString("/Account/Login"),
                    CookieDomain = ".domain.com",
                });
            }
        }
    }
