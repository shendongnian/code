    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        RegisterGlobalFilters(GlobalFilters.Filters);
        RegisterRoutes(RouteTable.Routes);
        // Register custom flag enum model binder
        ModelBinders.Binders.DefaultBinder = new CustomModelBinder();
    }
