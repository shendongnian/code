    /// <summary>
    /// Determines whether the given <paramref name="type"/> is a generic list
    /// </summary>
    /// <param name="type">The type to evaluate</param>
    /// <returns><c>True</c> if is generic otherwise <c>False</c></returns>
    public static bool IsGenericList(this Type type)
    {
        if (!type.IsGenericType) { return false; }
        
        var typeDef = type.GetGenericTypeDefinition();
        if (typeDef == typeof(List<>) || typeDef == typeof(IList<>)) { return true; }
        return false;
    }
