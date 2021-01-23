    var types = OpenGenericBatchRegistrationExtensions.GetTypesToRegister(
        _container,
        typeof (ICommandValidator<>),
        AccessibilityOption.PublicTypesOnly,
        typeof (ICommandValidator<>).Assembly)
        .ToList();
    types.Add(typeof(DataAnnotationsValidator<>));
    _container.RegisterAll(typeof(ICommandValidator<>), types);
