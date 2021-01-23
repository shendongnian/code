    private static bool IsOrImplementsICollection(Type t)
    {
        if (t == typeof (ICollection) || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof (ICollection<>)))
            return true;
        return t.GetInterfaces().Any(IsOrImplementsICollection);
    }
