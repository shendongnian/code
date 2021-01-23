    static Type GetDatabaseTypeArgument(Type type)
    {
        for (Type current = type; current != null; current = current.BaseType)
        {
            if (current.IsGenericType && current.GetGenericTypeDefinition() == typeof(Database<>))
            {
                return current.GetGenericTypeArguments()[0];
            }
        }
        throw new ArgumentException("Type incompatible with Database<T>");
    }
