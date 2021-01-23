    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            httpConfiguration
                .EnableSwagger()    // <==== EXTENSION METHOD <==== //
                .MapHttpAttributeRoutes();
            httpConfiguration.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional});
            appBuilder
                .UseWebApi(httpConfiguration);
        }
    }
