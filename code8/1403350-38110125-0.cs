    Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
    List<Assembly> myAssemblies = new List<Assembly>();
    foreach (Assembly assembly in assemblies)
    {
        if (assembly.GetName().Name.Contains("EX."))
        {
            myAssemblies.Add(assembly);
        }
    }
