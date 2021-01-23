    public static object GetDefaultValue(this ParameterInfo p)
    {
        if (!p.Attributes.HasFlag(ParameterAttributes.HasDefault))
        {
            return null;
        }
        if (p.DefaultValue != null || p.RawDefaultValue != null)
        {
            return p.DefaultValue ?? p.RawDefaultValue;
        }
        return p.ParameterType.IsValueType ? Activator.CreateInstance(p.ParameterType) : null;
    }
