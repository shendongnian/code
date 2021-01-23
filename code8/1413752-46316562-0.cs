    private static IEnumerable<Type> GetAllTypesOf<T>()
    {
        var platform = Environment.OSVersion.Platform.ToString();
        var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);
        return runtimeAssemblyNames
            .Select(Assembly.Load)
            .SelectMany(a => a.ExportedTypes)
            .Where(t => typeof(T).IsAssignableFrom(t));
    }
