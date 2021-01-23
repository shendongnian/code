    var enumerableType = typeof(Enumerable);
    var bar =
    (
        from m in enumerableType.GetMethods(BindingFlags.Static | BindingFlags.Public)
        where m.Name == "Any"
        let p = m.GetParameters()
        where p.Length == 2
            && p[0].ParameterType.IsGenericType
            && p[0].ParameterType.GetGenericTypeDefinition() == typeof(IEnumerable<>)
            && p[1].ParameterType.IsGenericType
            && p[1].ParameterType.GetGenericTypeDefinition() == typeof(Func<,>)
        select m
    ).SingleOrDefault();
