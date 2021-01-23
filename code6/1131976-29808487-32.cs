    container.Register(typeof(IGenericRepository<>), 
        typeof(GenericRepository<>));
    container.Register(typeof(ICommandHandler<>), 
        new[] { Assembly.GetExecutingAssembly() });
    container.RegisterDecorator(typeof(ICommandHandler<>), 
        typeof(SaveChangesCommandHandlerDecorator<>));
    container.RegisterDecorator(typeof(ICommandHandler<>),
        typeof(ThreadScopedCommandHandlerDecorator<>),
        Lifestyle.Singleton);
