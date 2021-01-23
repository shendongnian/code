    var container = new Container(config =>
    {
        var registries = (
            from assembly in AppDomain.CurrentDomain.GetAssemblies()
            from type in assembly.DefinedTypes
            where typeof(Registry).IsAssignableFrom(type)
            where !type.IsAbstract
            where !type.Namespace.StartsWith("StructureMap")
            select Activator.CreateInstance(type))
            .Cast<Registry>();
        foreach (var registry in registries)
        {
            config.AddRegistry(registry);
        }
    });
