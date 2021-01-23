    // Adding the (redundant) namespace of the type makes it very clear to the
    // user if this type is still located in the business layer.
    Assembly[] businessLayerAssemblies = new[] {
        typeof(MyComp.MyApp.BusinessLayer.AddPersonCommandHandler).Assembly
    }
    container.Register(typeof(ICommandHandler<>), businessLayerAssemblies);
    container.Register(typeof(IQueryHandler<,>), businessLayerAssemblies);
    container.Register(typeof(IEventHandler<>), businessLayerAssemblies);
    container.Register(typeof(IValidator<>), businessLayerAssemblies);
