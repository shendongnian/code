    public static object GetPropvalue(this object InputObject, string PropertyName)
    {
        Type type = InputObject.GetType();
        PropertyInfo p = type.GetProperty(PropertyName);
        return p.GetValue(InputObject);
    }
