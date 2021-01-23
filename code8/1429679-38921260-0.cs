var fileNames = Directory.GetFiles(path, "*.dll", searchOption);
    List<Assembly> assemblies = new List<Assembly>();
    foreach (string fileName in fileNames)
    {
        assemblies.Add(Assembly.LoadFrom(fileName));
    }
