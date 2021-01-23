    public override void RegisterArea(AreaRegistrationContext context) 
    {
        // Entry point for each action on Policy controller
        context.MapRoute(
            "Policy_default_detail",
            "Policy/Detail/{id}",
            new { controller = "Policy", action = "Detail", id = UrlParameter.Optional }
        );
        context.MapRoute(
            "Policy_default_anotheraction",
            "Policy/AnotherAction/{id}",
            new { controller = "Policy", action = "AnotherAction", id = UrlParameter.Optional }
        );
        // Default entry point
        context.MapRoute(
            "Policy_default",
            "Policy/{controller}/{action}/{id}",
            new { action = "Index", id = UrlParameter.Optional }
        );
    }
