    public override void RegisterArea(AreaRegistrationContext context) 
    {
        // Wire up any attribute based routing
        context.Routes.MapMvcAttributeRoutes();
        // Area routing omitted for brevity
    }
