     public override void RegisterArea(AreaRegistrationContext context)
     {
            context.MapRoute(
                "admin", // Route name
                "admin/{controller}/{action}/{id}", // URL with parameters
                new { controller = "YourControllerName", action = "YourActionName", area = "admin", id = UrlParameter.Optional } // Parameter defaults
            );
    }
