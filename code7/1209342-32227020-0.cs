    public static IEnumerable<object> ResolveAllOpenGeneric(this IUnityContainer container, Type openGenericType)
    {
        if (!openGenericType.IsGenericTypeDefinition)
            throw new ArgumentNullException("argument must be open generic type");
    
        return container.Registrations.Where(c =>
                                                c.RegisteredType.IsGenericType
                                                && c.RegisteredType.GetGenericTypeDefinition() == openGenericType
                                            )
                                            .Select(r =>
                                                        container.Resolve(r.RegisteredType, r.Name)
                                            );
    }
    
    public static IEnumerable<T> ResolveAllOpenGeneric<T>(this IUnityContainer container, Type openGenericType)
    {
        if (!openGenericType.IsGenericTypeDefinition)
            throw new ArgumentNullException("argument must be open generic type");
    
        return container.Registrations.Where(c =>
                                                 c.RegisteredType.IsGenericType
                                                 && c.RegisteredType.GetGenericTypeDefinition() == openGenericType
                                             )
                                             .Select(r =>
                                                         (T)container.Resolve(r.RegisteredType, r.Name)
                                             );
    }
