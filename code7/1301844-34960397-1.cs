    var types = container.GetTypesToRegister(typeof(IInterface<>), assemblies);
    // NOTE: The ToArray() call is crucial to prevent torn lifestyles.
    var registrations = (
        from type in types
        select Lifestyle.Singleton.CreateRegistration(type, type, container))
        .ToArray();
    container.RegisterCollection<IInterface>(registrations);
    foreach (var registration in registrations) {
        container.AddRegistration(
            typeof(IInterface<>).MakeGenericType(registration.ImplementationType),
            registration);
    }
