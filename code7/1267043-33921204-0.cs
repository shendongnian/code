    public static void Register(HttpConfiguration config)
    {
        config.SetCorsPolicyProviderFactory(new CorsPolicyFactory());
        config.EnableCors();
        // Web API routes
        config.MapHttpAttributeRoutes();
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );                     
    }
