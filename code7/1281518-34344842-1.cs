    internal static DbType LookupDbType(Type type, string name)
    {
        DbType dbType;
        var nullUnderlyingType = Nullable.GetUnderlyingType(type);
        if (nullUnderlyingType != null) type = nullUnderlyingType;
        if (type.IsEnum)
        {
            type = Enum.GetUnderlyingType(type);
        }
        if (typeMap.TryGetValue(type, out dbType))
        {
            return dbType;
        }
        throw new NotSupportedException(string.Format("The member {0} of type {1} cannot be used as a parameter value", name, type));
    }
