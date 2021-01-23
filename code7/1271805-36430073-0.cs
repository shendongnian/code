    var assemblies = PlatformServices.Default.LibraryManager.GetLibraries().SelectMany(l => l.Assemblies.Select(an =>
    {
    try
    { return Assembly.Load(an); }
    catch (ReflectionTypeLoadException)
    { return null; }
    })).Where(a => (object)a != null);
