    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapMvcAttributeRoutes();
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Foo", action = "Index", id = UrlParameter.Optional },
            // This will prioritize your existing Controllers so they work as expected  
            namespaces: new[] { "ProjectA.Controllers"}
        );
    }
