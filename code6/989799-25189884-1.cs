    // Register all implementations of ICommandHandler<T>
    container.RegisterManyForOpenGeneric(
        typeof(ICommandHandler<>),
        AppDomain.CurrentDomain.GetAssemblies());
    container.RegisterOpenGeneric(
        typeof(ICommandHandler<>),
        typeof(NullCommandHandler<>),
        Lifestyle.Singleton);
