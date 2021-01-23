    private ISet<Type> GetTypes(IEnumerable<string> assemblyPaths)
    {
        return new HashSet<Type>(assemblyPaths
            .Select(RuntimeContext.Current.LoadAssembly)
            .SelectMany(a => a.GetTypes())
            .Where(t => t.GetCustomAttribute<PluginTypeAttribute>() != null));
    }
