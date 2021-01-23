    [assembly: OwinStartup(typeof(MCWeb_3SR.Startup))]
    namespace MCWeb_3SR
    {
      public partial class Startup
      {
        public void Configuration(IAppBuilder app) {
          ConfigureAuth(app);
          ConfigureSignalR(app);
        }
      }
    }
