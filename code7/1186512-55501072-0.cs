    using Microsoft.Owin;
    using Owin;
    [assembly: OwinStartup(typeof(YourProjectName.Startup))]
    namespace YourProjectName
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                ConfigureAuth(app);
            }
        }
    }
