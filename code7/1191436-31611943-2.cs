    routes.MapRoute(
            "Default", // Route name
            "{controller}/{action}/{id}", // URL with parameters*
            new { controller = "Sales", action = "ProjectionReport", 
            id = UrlParameter.Optional }
    );
