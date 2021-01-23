    // Simple Injector v3.x
    container.Register(typeof(IGenericRepository<>), 
        typeof(GenericRepository<>));
    container.Register(typeof(ICommandHandler<>), 
        new[] { Assembly.GetExecutingAssembly() });
    container.RegisterDecorator(typeof(ICommandHandler<>), 
        typeof(SaveChangesCommandHandlerDecorator<>));
    container.RegisterDecorator(typeof(ICommandHandler<>),
        typeof(LifetimeScopedCommandHandlerDecorator<>),
        Lifestyle.Singleton);
    // Simple Injector v2.x
    container.RegisterOpenGeneric(typeof(IGenericRepository<>), 
        typeof(GenericRepository<>));
    container.RegisterManyForOpenGeneric(typeof(ICommandHandler<>), 
        Assembly.GetExecutingAssembly());
    container.RegisterDecorator(typeof(ICommandHandler<>), 
        typeof(SaveChangesCommandHandlerDecorator<>));
    container.RegisterDecorator(typeof(ICommandHandler<>),
        typeof(LifetimeScopedCommandHandlerDecorator<>),
        Lifestyle.Singleton);
