    public object CreateInstance(Type type, Object parameterMapping)
    {
        var ctors = type.GetConstructors();
        var properties = parameterMapping.GetType().GetProperties();
        foreach (var ctor in ctors)
        {
            var parameters = ctor.GetParameters();
            if (parameters.Length != properties.Length)
            {
                continue;
            }
            object[] args = new object[parameters.Length];
            bool success = true;
            for (int i = 0; i < parameters.Length; 
            {
                var property = parameterMapping.GetType().GetProperty(parameter.Name);
                if (property == null)
                {
                    success = false;
                    break;
                }
                // TODO: Check property type is appropriate too
                args[i] = property.GetValue(parameterMapping, null);
            }
            if (!success)
            {
                continue;
            }
            return ctor.Invoke(args);
        }
        throw new ArgumentException("No suitable constructor found");
    }
