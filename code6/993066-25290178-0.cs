    foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
    {
        if (type.IsGenericTypeDefinition || type.IsInterface)
            continue;
        RuntimeHelpers.RunClassConstructor(type.TypeHandle);
        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
            RuntimeHelpers.PrepareMethod(method.MethodHandle);
    }
