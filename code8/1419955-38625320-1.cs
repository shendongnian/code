    public static object GetPropvalue(this object InputObject, string PropertyName)
    {
        Type type = InputObject.GetType();
        PropertyInfo p = type.GetProperty(PropertyName);
        if (p != null)
        {
            return p.GetValue(InputObject);
        }
        else
        {
            return null;
        }
    }
