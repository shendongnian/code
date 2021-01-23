    // using SimpleInjector.Extensions;
    // Batch register all handlers in the system.
    container.RegisterManyForOpenGeneric(typeof(IHandler<>), 
        typeof(AssignmentHandler).Assembly);
    // Register the open-generic MultipleHandler<TFor>
    container.RegisterOpenGeneric(typeof(IHandler<>), typeof(MultipleHandler<>));
