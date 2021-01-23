    IEnumerable<Type> oneParameterTypes = Assembly.GetAssembly(typeof (object))
        .GetTypes()
        .Where(t => t.IsGenericType)
        .Where(t => t.GetGenericArguments().Length == 1)
        .Where(t => t.GetGenericArguments().Single().GetGenericParameterConstraints().Length == 0 &&
                    !genericArgument.GenericParameterAttributes.HasFlag(GenericParameterAttributes.ReferenceTypeConstraint);
        });
