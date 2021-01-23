    protected void Application_Start()
    {
          AreaRegistration.RegisterAllAreas();
          ...
          // other code here
          ...
          ViewEngines.Engines.Add(new ViewEngine()); // add your custom view engine above
    }
