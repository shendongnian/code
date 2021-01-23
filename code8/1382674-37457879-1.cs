    public void Configuration(IAppBuilder appBuilder)
    {
        var httpConfiguration = new HttpConfiguration();
        httpConfiguration.Services.Replace(typeof(IExceptionHandler), new ExampleExceptionHandler());
        httpConfiguration.Services.Add(typeof(IExceptionLogger), new ExampleExceptionLogger());
            
        httpConfiguration.MapHttpAttributeRoutes();
        // httpConfiguration.EnableCors();
            
        appBuilder.UseOwinExceptionHandler();
        appBuilder.UseCors(CorsOptions.AllowAll); // Use Owin Cors
        appBuilder.UseWebApi(httpConfiguration);
    }
