    using Microsoft.AspNet.Identity;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Owin;
    
    [assembly: OwinStartup(typeof(appNamespace.OwinStartup))]
    
    namespace appNamespace
    {
        public class OwinStartup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login")
                });
    
            }
        }
    }
