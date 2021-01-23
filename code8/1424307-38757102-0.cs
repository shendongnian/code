    public static IContainer RegisterServices(IServiceCollection services)
    {
        // Create the container builder.
        var builder = new ContainerBuilder();           
    
        var assembly = Assembly.GetExecutingAssembly();
    
        builder.RegisterAssemblyTypes(assembly)
        	   .Where(t => t.GetTypeInfo().IsSubclassOf(typeof(ServiceInjectionModule)))
        	   .AsSelf();
    
        // Add automapper configurations            
        var mapperConfiguration = AutoMapperConfig.Configure(); 
        var mapper = mapperConfiguration.CreateMapper();
        builder.RegisterInstance(mapper).As<IMapper>();
    
        // Populate default services
        builder.Populate(services);
    
        return builder.Build();
    }
