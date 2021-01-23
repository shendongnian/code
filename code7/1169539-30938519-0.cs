    public static FieldInfo[] DeclaredFields(TypeInfo type)
    {
        var fields = new List<FieldInfo>();
        while (type != null)
        {
            fields.AddRange(type.DeclaredFields);
            Type type2 = type.BaseType;
            type = type2 != null ? type2.GetTypeInfo() : null;
        }
        return fields.ToArray();
    }
