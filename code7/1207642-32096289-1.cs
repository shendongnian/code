    [assembly: OwinStartup(typeof(YourPorject.Startup))]
    namespace YourPorject
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                AuthConfig.ConfigureAuth(app);
            }
        }
    
    }
