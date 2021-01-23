    public void ConfigureServices(IServiceCollection services)
    {
        HomeController controller;
        var controllerFactory = Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateFactory(typeof(HomeController), Type.EmptyTypes);
        controller = (HomeController)controllerFactory(services.BuildServiceProvider(), null);
    }
