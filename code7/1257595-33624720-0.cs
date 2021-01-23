    .OrderBy(o => keySelector(o, propertyName))
    public static Type VariableType(object o, string prop)
    {
        Type type = typeof(TResource);
        PropertyInfo pi = type.GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        return pi.GetValue(o);
    }
