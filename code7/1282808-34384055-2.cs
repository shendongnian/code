    private static Dictionary<Type, Func<IList>> funcs;
    public static IList MakeList(Type listType)
    {
        Func<IList> f;
        // checks to ensure listType is a generic list omitted...
        if(!funcs.TryGetValue(listType, out f)) {
            // gets the generic argument e.g. string for a List<string>
            var genericType = listType.GetGenericArguments()[0];
            var ctor = typeof(List<>)
                       .MakeGenericType(genericType)
                       .GetConstructor(Type.EmptyTypes);
            f = Expression.Lambda<Func<IList>>(
                Expression.New(ctor, new Expression[]{})).Compile();
            funcs[listType] = f;
        }
        return f();
    }
