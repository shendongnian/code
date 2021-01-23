    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Cookies;
    
    namespace TestOwin
    {
        public class Startup
        {
            // OWIN Configuration goes here
            public static void Configuration(IAppBuilder app)
            {
                var cookieOptions = new CookieAuthenticationOptions() { AuthenticationMode = AuthenticationMode.Active };
                var nancyCfg = new NancyOptions();
                nancyCfg.Bootstrapper = new NBootstrapper();
                app.UseStaticFiles();
                app.UseCookieAuthentication(cookieOptions);
                app.UseNancy(nancyCfg);
    
            }
            
        }
    }
