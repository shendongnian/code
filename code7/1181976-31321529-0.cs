    builder.Register(c => new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers))
           .As<IConfigurationProvider>()
           .SingleInstance();
    builder.RegisterType<MappingEngine>()
           .As<IMappingEngine>();
