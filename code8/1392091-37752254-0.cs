    var instance = ...
    var @interface =
        instance.GetType()
            .GetInterfaces()
            .FirstOrDefault(i =>
                i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof (IDeclaration<>));
    bool is_IDeclaration = @interface != null;
