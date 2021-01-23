    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            //set the webApi resolver here!
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(DependencyInjectionCoreSetup._Container);
            //then the rest..
            var route = config.Routes.MapHttpRoute(
            ....
        }
    }
