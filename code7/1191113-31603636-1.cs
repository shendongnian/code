    // Simple Injector v3.x
    container.RegisterConditional(
        typeof(IAdditionalDataService<,>),
        typeof(EmptyAdditionalDataService<,>),
        c => !c.Handled);
    // Simple Injector v2.x
    container.RegisterOpenGeneric(
        typeof(IAdditionalDataService<,>),
        typeof(EmptyAdditionalDataService<,>));
