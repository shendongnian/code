    public static IEnumerable<Type> GetAllSubTypesInSameAssembly(this Type type)
    {
        return type.Assembly
                   .GetTypes()
                   .Where(t => t != type && type.IsAssignableFrom(t));
    }
