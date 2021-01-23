    public static void Register(HttpConfiguration config)
    {
        var c = new Container().WithWebApi(config);
        
        c.Register<IWidgetService, WidgetService>(Reuse.Singleton);
        c.Register<IWidgetRepository, WidgetRepository>(Reuse.Singleton);
        // Resolve service first then inject properties into it.
        var ws = c.Resolve<IWidgetService>();
        c.InjectPropertiesAndFields(ws);
    }
