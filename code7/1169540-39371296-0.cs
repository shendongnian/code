    public static IEnumerable<FieldInfo> DeclaredFields(Type type)
        {
            var fields = new List<FieldInfo>();
            while (type != null)
            {
                fields.AddRange(type.GetRuntimeFields());
                type = type.GetTypeInfo().BaseType;
            }
            return fields;
        }
