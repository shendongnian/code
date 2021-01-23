    var concretes =
        Assembly
        .GetAssembly(typeof (Concrete))
        .GetTypes()
        .Where(t =>
            t.GetInterfaces()
            .Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ITest<,>)))
        .ToList();
