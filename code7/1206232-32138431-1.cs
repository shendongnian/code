    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
 
        // Register global filter
        GlobalFilters.Filters.Add(new MyBaconActionFilterAttribute());
    
        RegisterGlobalFilters(GlobalFilters.Filters);
        RegisterRoutes(RouteTable.Routes);
    }
