    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Owin;
    using Owin.Security.Providers.Steam;
    namespace WebApplication
    {
        public partial class Startup
        {
        
            public void ConfigureAuth(IAppBuilder app)
            {
                //other Config
                app.UseSteamAuthentication("your API key");
            }
        }
    }
