    public void Configuration(IAppBuilder app)
    {
        var config = new HttpConfiguration();
        WebApiConfig.Register(config);
        app.UseNinjectMiddleware(() => NinjectDependencyResolver.CreateKernel.Value);
        app.UseNinjectWebApi(config);
        ConfigureAuth(app);
        app.UseWebApi(config); //Web API is on the OWIN pipeline now
    }
