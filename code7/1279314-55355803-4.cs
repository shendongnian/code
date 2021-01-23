    public static void Register(HttpConfiguration config)
    {
        config.MapHttpAttributeRoutes();
         
        // New code start
        ODataModelBuilder builder = new ODataConventionModelBuilder();
        builder.EntitySet<Foo>("Foos");
        builder.EntitySet<Bar>("Bars");
        config.MapODataServiceRoute(
            routeName: "ODataRoute",
            routePrefix: null,
            model: builder.GetEdmModel());
    
        config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
    
        config.EnableDependencyInjection();
        // New code end
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
    }
