    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Get our http configuration
            var config = new HttpConfiguration();
            // Register all areas
            AreaRegistration.RegisterAllAreas();  
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // Use our web api
            app.UseWebApi(config);
        }
    }
