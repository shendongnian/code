    public static IEnumerable<IVideoSource> GetVideoSources(List<string> assemblyPathes)
    {
        IEnumerable<Assembly> yourAssembliesWithClasses = assemblyPathes.Select(x => Assembly.Load(x));
        IEnumerable<Type> implementingTypes = yourAssembliesWithClasses.GetTypes().Where(x => x.IsAssignableFrom(IVideoSource));
        return implementingTypes.Select(x => Activator.CreateInstance(x));
    }
