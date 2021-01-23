    public static bool IsOfAnyType(object obj, Type[] types)
    {
        foreach (var type in types)
        {
            if (obj.GetType() == type)
                return true;
        }
        return false;
    }
