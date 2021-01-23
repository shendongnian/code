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
                    
                    // If you need to differentiate between a generic arg that is declared
                    // in the method versus being declared in the class/interface/struct:
                    if (genericArg.DeclaringMethod == null)
                    {
                        // Declared in the class/interface/struct
                    }
                    else
                    {
                        // Declared in the method
                    }
                }
            }
        }
    }
