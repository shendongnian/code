     public void ConfigureServices(IServiceCollection services)
        {
             services.AddSingleton<IState, State>();
            //... other services
            GlobalHost.DependencyResolver = new CustomSignalRDependencyResolver(services.BuildServiceProvider());
        }
