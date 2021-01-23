    public static class New
    {
        public static readonly Func<Type, IList> MakeList = t => MakeListImpl(t)();
    
        private static readonly IDictionary<Type, Func<IList>> Cache = new Dictionary<Type, Func<IList>>();
        private static Func<IList> MakeListImpl(Type listType)
        {
            Ensure.That(listType.IsGenericList());
    
            Func<IList> result;
            if (!Cache.TryGetValue(listType, out result))
            {
                var genericArg = listType.GetGenericArguments()[0];
                var concreteType = typeof(List<>).MakeGenericType(genericArg);
    
                result = Expression.Lambda<Func<IList>>(Expression.New(concreteType)).Compile();
                Cache[listType] = result;
            }
    
            return result;
        }
    }
