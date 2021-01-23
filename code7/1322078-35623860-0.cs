    container.Register(typeof(IValidator<>), assemblies);
    var t1 = container.GetTypesToRegister(typeof(IValidator<>), assemblies);
    var t2 = container.GetTypesToRegister(typeof(IValidator<>), assemblies,
        new TypesToRegisterOptions { IncludeDecorators = true });
    foreach (Type t in t2.Except(t1)) {
        container.RegisterDecorator(typeof(IValidator<>), t);
    }
