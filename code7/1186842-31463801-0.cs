    public static List<T> GetAllDerivedTypes<T>(this Assembly assembly)
    {
        // …
        List<object> types = new List<object>();
        foreach (var definedType in assembly.DefinedTypes)
        {
            // …
            types.Add(definedType);
        }
    
        return types.Cast<T>().ToList();
    }
