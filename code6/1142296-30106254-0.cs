       protected void Application_Start()
       {
            Container = UnityConfig.InitializeUnity();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ...
