    container.RegisterOpenGeneric(
        typeof(ICommandHandler<>),
        AppDomain.CurrentDomain.GetAssemblies());
    var registrations =
        from assembly in assemblies
        from type in assembly.GetExportedTypes()
        where !type.IsAbstract && !type.IsGenericType
        from @interface in type.GetInterfaces()
        where !@interface.IsGenericType
		select new { Service = @interface, Implementation = type };
    foreach (var registration in registrations)
    {
        container.Register(registration.Service, registration.Implementation);
    }
