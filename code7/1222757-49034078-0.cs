    public void ConfigureServices(IServiceCollection services)
    {
        IServiceProvider serviceProvider = services.BuildServiceProvider();
        IHostingEnvironment env = serviceProvider.GetService<IHostingEnvironment>();
        
        if (env.IsProduction()) DoSomethingDifferentHere();
    }
