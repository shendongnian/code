    public static class EntityExtensions
    {
        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> query, 
            Expression<Func<T,TProperty>> include) where T : class
        {
            TestDB.Includes.Add(include);
            var method = typeof(QueryableExtensions)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "Include")
                .First(m => m.GetParameters().All(p => p.ParameterType.IsGenericType));
            var generic = method.MakeGenericMethod(typeof(T), typeof(TProperty));
            return (IQueryable<T>)generic.Invoke(query, new object[] { query, include });
        }
    }
