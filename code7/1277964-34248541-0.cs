    if (method.ContainsGenericParameters)
    {
        foreach (var parameter in method.GetParameters())
        {
            if (parameter.ParameterType.IsArray)
            {
                var elementType = parameter.ParameterType.GetElementType();
                var genericArgName = elementType.Name;
                var genericParameterPosition = elementType.GenericParameterPosition;
            }
            else if (parameter.ParameterType.IsGenericType)
            {
                foreach (var genericArg in parameter.ParameterType.GetGenericArguments())
                {
                    var genericArgName = genericArg.Name;
                    var genericParameterPosition = genericArg.GenericParameterPosition;
                }
            }
        }
    }
