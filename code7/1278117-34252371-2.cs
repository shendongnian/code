    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = GlobalConfiguration.Configuration;
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
            config.EnsureInitialized();
        }
    }
