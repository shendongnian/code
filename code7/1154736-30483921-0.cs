    public static object ChangeType(object value, Type type)
    {
        // returns null for non-nullable types
        Type type2 = Nullable.GetUnderlyingType(type);
        if (type2 != null)
        {
            if (value == null)
            {
                return null;
            }
            type = type2;
        }
        return Convert.ChangeType(value, type);
    }
