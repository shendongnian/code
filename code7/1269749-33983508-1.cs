    public static void Config()
    {
        var configuration_store = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
        var mapping_engine = new MappingEngine(configuration_store);
        configuration_store.CreateMap<Student, StudentViewModel>();
        var builder = new ContainerBuilder();
        builder.RegisterInstance(mapping_engine).As<IMappingEngine>();
            
        //...
        var container = builder.Build();
        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }
