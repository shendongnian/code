    [assembly: OwinStartup(typeof(UPARMobileApp.Startup))]
    
    namespace UPARMobileApp
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                ConfigureOWinContext(app);
                ConfigureMobileApp(app);            
            }
        }
    }
    public static void ConfigureOWinContext(IAppBuilder app)
    {
        // Configure the db context and user manager to use a single instance per request
        app.CreatePerOwinContext(ApplicationDbContext.Create);
        app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
    }
