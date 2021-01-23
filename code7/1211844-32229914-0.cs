    static void Main()
    {
        MethodInfo method = typeof(Test).GetMethod("Refer");
        ParameterInfo[] parameters = method.GetParameters();
        foreach (ParameterInfo parameter in parameters)
        {
            Type paramType = parameter.ParameterType;
            Console.WriteLine("Type of {0} is {1}", parameter.Name, paramType.Name);
            Console.WriteLine("{0} is passed by ref   : {1}", parameter.Name, paramType.IsByRef ? "Yes" : "No");
            // extracting element type (works for arrays, too)
            if (paramType.IsByRef)
                paramType = paramType.GetElementType();
            // this will print Yes for a ref int
            Console.WriteLine("{0} is a primitive type: {1}", parameter.Name, paramType.IsPrimitive ? "Yes" : "No");
            // ...
        }
    }
