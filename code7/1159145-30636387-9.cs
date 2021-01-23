    // Simple Injector v3.x
    container.RegisterCollection(typeof(IEventHandler<>), listOfAssembliesToSearch);
    // Simple Injector v2.x
    container.RegisterManyForOpenGeneric(
        typeof(IEventHandler<>),
        container.RegisterAll,
        listOfAssembliesToSearch);
