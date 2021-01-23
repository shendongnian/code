    container.ResolveUnregisteredType += (s, e) =>
    {
        var type = e.UnregisteredServiceType;
        if (!type.IsGenericType || 
            type.GetGenericTypeDefinition() != typeof(Func<>))
            return;
        Type serviceType = type.GetGenericArguments().First();
        InstanceProducer producer = container.GetRegistration(serviceType, true);
        Type funcType = typeof(Func<>).MakeGenericType(serviceType);
        var factoryDelegate =
            Expression.Lambda(funcType, producer.BuildExpression()).Compile();
        e.Register(Expression.Constant(factoryDelegate));
    };
