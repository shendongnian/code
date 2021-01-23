    public static class ObjectExtensionMethod
    {
        public static IQueryable Select(this IQueryable source, Expression<Func<dynamic, dynamic>> map)
        {
            try
            {
                var method = new Func<IQueryable<dynamic>, Expression<Func<dynamic, dynamic>>, IQueryable<dynamic>>(Queryable.Select).Method;
                Expression conversion = Expression.Convert(source.Expression, typeof(System.Linq.IQueryable<dynamic>));
                var call = Expression.Call(null, method, conversion, Expression.Quote(map));
                return source.Provider.CreateQuery(call);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static IQueryable Where<T>(this IQueryable source, Expression<Func<T, bool>> predicate)
        {
            try
            {
                var method = new Func<IQueryable<T>, Expression<Func<T, bool>>, IQueryable<T>>(Queryable.Where).Method;
                Expression conversion = Expression.Convert(source.Expression, typeof(System.Linq.IQueryable<T>));
                var call = Expression.Call(null, method, conversion, predicate);
                return source.Provider.CreateQuery(call);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static IEnumerable<dynamic> ToList(this IQueryable source)
        {
            return source as dynamic;
        }
    }
