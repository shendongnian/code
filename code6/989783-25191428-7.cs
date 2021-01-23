    var scopedLifestyle = new WebRequestLifestyle();
    var container = new Container();
    container.RegisterOpenGenericAccordingToLifestyleAttribute(
        typeof(ICommandHandler<>),
        AppDomain.CurrentDomain.GetAssemblies());
    var registrations =
        from assembly in assemblies
        from type in assembly.GetExportedTypes()
        where type !type.IsAbstract && !type.IsGenericType
        from @interface in type.GetInterfaces()
        where !@interface.IsGenericType
		select new { Service = @interface, Implementation = type };
    foreach (var registration in registrations)
    {
        container.RegisterAccordingToLifestyleAttribute(
            registration.Service, registration.Implementation);
    }
