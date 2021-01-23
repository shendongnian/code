        HttpConfiguration config = new HttpConfiguration();
    app.UseNinjectMiddleware(NinjectContainer.CreateKernel);
    app.UseNinjectWebApi(GlobalConfiguration.Configuration);
    ConfigureOAuth(app);
    WebApiConfig.Register(config);
    //GlobalConfiguration.Configure(WebApiConfig.Register);
    app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
    // app.UseWebApi(GlobalConfiguration.Configuration);
    app.UseWebApi(config);
    app.UseWelcomePage();
    
