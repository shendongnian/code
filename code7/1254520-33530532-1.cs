    IEnumerable<Type> oneParameterTypes = Assembly.GetAssembly(typeof (object))
        .GetTypes()
        .Where(t => t.IsGenericType)
        .Where(t => t.GetGenericArguments().Length == 1)
        .Where(t =>
        {
            var genericArgument = t.GetGenericArguments().Single();
            return genericArgument.GetGenericParameterConstraints().Length == 0 &&
                   genericArgument.GenericParameterAttributes != GenericParameterAttributes.ReferenceTypeConstraint;
        });
