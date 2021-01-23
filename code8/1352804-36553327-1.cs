    [assembly: OwinStartupAttribute(typeof(signalRTest.Startup))]
    namespace signalRTest
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                map.UseCors(CorsOptions.AllowAll);
                map.RunSignalR();
            }
        }
    }
