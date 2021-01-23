    var valuesController = new ValuesController()
    {
        Request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/api/") },
        Configuration = new HttpConfiguration()
    };
    
    valuesController.Configuration.MapHttpAttributeRoutes();
    valuesController.Configuration.EnsureInitialized();
    
    valuesController.Get();
