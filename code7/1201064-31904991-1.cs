    [assembly: OwinStartup(typeof(Startup))]
    
    namespace Omu.ProDinner.WebUI
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                OwinConfig.ConfigureAuth(app);
            }
        }
    }
