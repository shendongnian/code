    string[] input = //CLI arguments separated by ,
    // "YourType" is the type that holds your method
    MethodInfo targetMethod = typeof(YourType).GetMethod("MyMethod");
    
    // YourMethod's parameters
    ParameterInfo[] parameters = targetMethod.GetParameters();
    
    // This will contain the converted values
    object[] arguments = new object[input.Length];
    for(int i = 0; i < input.Length; i++)
    {
        Type paramType = parameters[i].ParameterType;
        if (paramType.IsArray)
        {
            string[] arrayValues = input[i]
                                   .Replace("[", String.Empty)
                                   .Replace("]", String.Empty)
                                   .Split(',');
            arguments[i] = arrayValues
                        .Select(v => Convert.ChangeType(v, paramType.GetElementType())
                        .ToArray();
        }
        else
            arguments[i] = Convert.ChangeType(input[i], paramType);
    }
