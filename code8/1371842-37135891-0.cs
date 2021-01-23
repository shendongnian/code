    public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Doctor", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "DoctorSearchEngine.Controllers" }
            );
           
        }
