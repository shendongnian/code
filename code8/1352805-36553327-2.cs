    [assembly: OwinStartupAttribute(typeof(signalRTest.Startup))]
    namespace signalRTest
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseCors(CorsOptions.AllowAll);
                app.MapSignalR();
            }
        }
    }
