    container.RegisterTypes(
        AllClasses
        .FromLoadedAssemblies()
        .Where(t => 
            t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>))),
        WithMappings.FromAllInterfaces);
