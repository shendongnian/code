    public static bool IsOfAnyType(object obj, Type[] types)
    {
        foreach (var type in types)
        {
            if (type.IsInstanceOfType(obj))
                return true;
        }
        return false;
    }
