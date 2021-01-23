    public Type FindType(string typeName, string assemblyName)
    {
        Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(a => a.GetName().Name == assemblyName);
        return assembly != null ? assembly.GetTypes().SingleOrDefault(t => t.Name == typeName) : null;
    }
