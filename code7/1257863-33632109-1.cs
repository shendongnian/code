    protected void Application_Start()
    {
       AreaRegistration.RegisterAllAreas();
       RouteConfig.RegisterRoutes(RouteTable.Routes);
    
       ModelBinders.Binders.Add(typeof(Dictionary<string,int>), new MyCustomModelBinder());
    }
