    // Register All Types by Convention by default
    container.RegisterTypes(
        AllClasses.FromLoadedAssemblies(),
        WithMappings.FromMatchingInterface,
        WithName.Default,
        WithLifetime.Transient);
    // Overwrite All Types marked as Singleton
    container.RegisterTypes(
        AllClasses.FromLoadedAssemblies()
            .Where(t => t.GetCustomAttributes<SingletonAttribute>(true).Any()),
        WithMappings.FromMatchingInterface,
        WithName.Default,
        WithLifetime.ContainerControlled,
        null,
        true); // Overwrite existing mappings without throwing
