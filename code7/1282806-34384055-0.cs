    private static Dictionary<Type, Func<IList>> funcs;
    public static IList MakeList(Type listType)
    {
        // checks to ensure listType is a generic list omitted...
        Func<IList> f;
        if(!funcs.TryGetValue(listType, out f)) {
            var ctor = listType.GetConstructor(Type.EmptyTypes)
            f = Expression.Lambda<Func<IList>>(
                Expression.New(ctor, new Expression[]{});
            funcs[listType] = f;
        }
        return f();
    }
