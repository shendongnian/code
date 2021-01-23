    container.RegisterTypes(
        AllClasses.FromLoadedAssemblies().Where(type => typeof(IJob).IsAssignableFrom(type) && type.IsClass),
        WithMappings.FromAllInterfaces,
        t => t.IsNested ? t.DeclaringType.Name + "." + t.Name : t.Name,
        WithLifetime.Transient);
