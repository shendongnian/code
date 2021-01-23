    public static Func<IEnumerable<object>, object> GetAndFillListMethod(Type genericType)
    {
        var listType = typeof(List<>);
        var listGenericType = listType.MakeGenericType(genericType);
        var values = Expression.Parameter(typeof(IEnumerable<object>), "values");
        var ctor = listGenericType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new Type[0], null);
        // I prefer using Expression.Variable to Expression.Parameter
        // for internal variables
        var instance = Expression.Variable(listGenericType, "list");
        var assign = Expression.Assign(instance, Expression.New(ctor));
        var addMethod = listGenericType.GetMethod("AddRange", new[] { typeof(IEnumerable<>).MakeGenericType(genericType) });
        // Enumerable.Cast<T>
        var castMethod = typeof(Enumerable).GetMethod("Cast", new[] { typeof(IEnumerable) }).MakeGenericMethod(genericType);
        // For the parameters there is a params Expression[], so no explicit array necessary
        var castCall = Expression.Call(castMethod, values);
        var addCall = Expression.Call(instance, addMethod, castCall);
        var block = Expression.Block(
                new[] { instance },
                assign,
                addCall,
                Expression.Convert(instance, typeof(object))
            );
        return (Func<IEnumerable<object>, object>)Expression.Lambda(block, values).Compile();
    }
