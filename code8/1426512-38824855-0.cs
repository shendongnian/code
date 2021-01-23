    foreach (var method in methods)
    {
        var parameters = method.GetParameters();
        if (parameters.Length != 1)
        {
            //decide what to do here
            throw new Exception("More than one parameter found");
        }
        var requestType = parameters[0].ParameterType;
        var serviceControllerResultAttribute = method.GetCustomAttribute<ServiceControllerResultAttribute>();
        if (serviceControllerResultAttribute == null)
        {
            //decide what to do here
            throw new Exception("ServiceControllerResultAttribute was not found");
        }
        var resultType = serviceControllerResultAttribute.Type;
    }
