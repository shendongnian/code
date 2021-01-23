var fileNames = Directory.GetFiles(path, "*.dll", searchOption);
    List<Assembly> assemblies = new List<Assembly>();
    foreach (string fileName in fileNames)
    {
        assemblies.Add(Assembly.LoadFrom(fileName));
    }
[Edit]
If you are attempting to load the assemblies for later use in the application (e.g. you have reference to the assembly in Visual Studio), it is recommend that you implement the AppDomain.AssemblyResolve event. The AppDomain.AssemblyResolve event will fire when an assembly cannot be found and needs to be loaded. At that time you can provide the AppDomain an assembly in a different file location.
