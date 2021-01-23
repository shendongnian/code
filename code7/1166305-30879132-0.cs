    public static class ObjectExtensionMethod
    {
        public static IQueryable Select<T>(this IQueryable source, Expression<Func<dynamic, dynamic>> map)
        {
            var method = new Func<IQueryable<dynamic>, Expression<Func<dynamic, dynamic>>, IQueryable<dynamic>>(Queryable.Select).Method;
            var call = Expression.Call(null, method, source.Expression, Expression.Quote(map));
            return source.Provider.CreateQuery(call);
        }
        public static IQueryable Where(this IQueryable source, Expression<Func<dynamic, bool>> predicate)
        {
            var method = new Func<IQueryable<dynamic>, Expression<Func<dynamic, bool>>, IQueryable<dynamic>>(Queryable.Where).Method;
            var call = Expression.Call(null, method, source.Expression, Expression.Quote(predicate));
            return source.Provider.CreateQuery(call);
        }
    }
