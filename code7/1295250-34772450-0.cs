    // register every service except for ServiceBase
    Builder.RegisterAssemblyTypes(_modelAssemblies)
        .Where(t => typeof(IService).IsAssignableFrom(t) && (t != typeof(ServiceBase)))
        .InstancePerDependency();
    // register generic ServiceHandle
    Builder.RegisterGeneric(typeof(ServiceHandle<>))
        .AsSelf()
        .AsImplementedInterfaces()
        .InstancePerDependency();
    
