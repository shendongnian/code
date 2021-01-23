    public class Startup
    {
        // ReSharper disable once UnusedMember.Global
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            appBuilder.Use<LoggingMiddleware>();
            appBuilder.UseWebApi(config);
        }
    }
