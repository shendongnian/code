    Type type = typeof(Generic<>).MakeGenericType(field.FieldType);
    // Object of type Generic<field.FieldType>
    object gen = Activator.CreateInstance(type);
    MethodInfo isArray = type.GetMethod("IsArray");
    bool result = (bool)isArray.Invoke(gen, null);
