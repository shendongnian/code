    _container.RegisterTypes(
        AllClasses.FromAssembliesInBasePath()
            .Where(type => (typeof(IJob).IsAssignableFrom(type) || typeof(IJobPayload).IsAssignableFrom(type)) && type.IsClass),
        WithMappings.FromAllInterfaces,
        t => t.IsNested ? t.DeclaringType.Name + "." + t.Name : t.Name,
        WithLifetime.Transient);
