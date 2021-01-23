    ParameterInfo pi = ...;
    if (pi.ParameterType.IsArray && pi.ParameterType.GetElementType().IsEnum)
    {
        var enumArray = ToEnumArray(pi.ParameterType.GetElementType(), GetTabInt());
        param.Add(enumArray);
    }
