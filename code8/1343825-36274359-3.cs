    routes.MapRoute(
        "Default", 
        "{controller}/{action}/{id}", 
        new { controller = "Home", action = "Index", id = UrlParameter.Optional },
        namespaces: new[] { "RecreationalServicesTicketingSystem.Controllers" }
    );
