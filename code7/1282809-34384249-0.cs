    public static class New
    {
      public static readonly Func<Type, IList> Instance = t => MakeList(t)();
    
      private static readonly Dictionary<Type, Func<IList>> Cache = new Dictionary<Type, Func<IList>>();
      private static Func<IList> MakeList(Type listType)
      {
          // checks to ensure listType is a generic list omitted...
          
          Func<IList> result;
          if (!Cache.TryGetValue(listType, out result))
          {
              var genericType = listType.GetGenericArguments()[0];
    
              var ctor = typeof(List<>)
                  .MakeGenericType(genericType)
                  .GetConstructor(Type.EmptyTypes);
              result = Expression.Lambda<Func<IList>>(Expression.New(ctor, new Expression[] { })).Compile();
              Cache[listType] = result;
          }
    
          return result;
      }
    }
