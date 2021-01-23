    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
     services.AddMvc();
 
     var builder = new ContainerBuilder();
     builder.Populate(services);
     var container = builder.Build();
     return container.Resolve<IServiceProvider>();
    }
