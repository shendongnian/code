    protected void Application_Start()
    {
        var jsonMediaTypeFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
        jsonMediaTypeFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
        jsonMediaTypeFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    }
