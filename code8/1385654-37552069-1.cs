    public static void Register(HttpConfiguration config)
    {
        config.MapHttpAttributeRoutes();
    
        config.Routes.MapHttpRoute(
            name: "MyCustomApi",
            routeTemplate: "api/users/sharepoint/{id}",
            defaults: new { controller = "SharePoint", id = RouteParameter.Optional }
        );
    
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
    }
