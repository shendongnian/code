    public static IEnumerable<T> GetAll()
    {
        var assembly = Assembly.GetEntryAssembly();
        var assemblies = assembly.GetReferencedAssemblies();
        foreach (var assemblyName in assemblies)
        {
            assembly = Assembly.Load(assemblyName);
            foreach (var ti in assembly.DefinedTypes)
            {
                if (ti.ImplementedInterfaces.Contains(typeof(T)))
                {
                    yield return (T)assembly.CreateInstance(ti.FullName);
                }
            }
        }            
    }
