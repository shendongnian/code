        var def = parameter.DefaultValue;
        if (parameter.ParameterType.IsValueType && def == null) {
            def = Activator.CreateInstance(parameter.ParameterType);
        }
        Console.WriteLine(parameter.Name +
                          " of type " + parameter.ParameterType.ToString() +
                          " with default value:" + def);
