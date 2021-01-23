    public static List<Type> GetAllDerivedTypes<T>(this Assembly assembly)
    {
        // …
        List<Type> types = new List<Type>();
        foreach (var definedType in assembly.DefinedTypes)
        {
            // …
            types.Add(definedType);
        }
    
        return types;
    }
