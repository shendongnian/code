    // Get the Register<T1,T2>() method
    MethodInfo methodInfo =
        SimpleIoc.Default.GetType().GetMethods()
                 .Where(m => m.Name == "Register")
                 .Where(m => m.IsGenericMethod)
                 .Where(m => m.GetGenericArguments().Length == 2)
                 .Where(m => m.GetParameters().Length == 0)
                 .Single();
    // Create the generic type parameters to the method
    Type interfaceType = Type.GetType(service.Interface);
    Type implementationType = Type.GetType(service.Implementation);
    // Create a version of the method that takes your types
    methodInfo = methodInfo.MakeGenericMethod(interfaceType, implementationType);
    // Invoke the method on the default container (no parameters)
    methodInfo.Invoke(SimpleIoc.Default, null);
