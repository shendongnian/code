    IEnumerable<AssemblyName> names = DependencyContext.Default.GetDefaultAssemblyNames();
    foreach (AssemblyName name in names)
    {
        if (name.Name.StartsWith("MyRoot") == true)
        {
            Assembly assembly = Assembly.Load(name);
            // Process assembly here...
            // I will check attribute for each loaded assembly found in MyRoot.
        }
    }
