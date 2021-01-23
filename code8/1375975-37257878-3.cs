    public void Configuration(IAppBuilder app)
    {
        var config = new HttpConfiguration();
        WebApiConfig.Register(config);
        app.UseNinjectMiddleware(() => NinjectDependencyResolver.CreateKernel.Value);
        ConfigureAuth(app);
        app.UseNinjectWebApi(config);
    }
