    public static class OrderByExtensions
    {
        public static IQueryable<TSource> OrderByField<TSource>(this IQueryable<TSource> query, string fieldName, bool isAscending = true)
        {
            var prop = TypeDescriptor.GetProperties(typeof(TSource)).Find(fieldName, false);
            if (prop == null)
                return query;
            var sourceExpr = Expression.Parameter(typeof(TSource), "source");
            var propExpr = Expression.Property(sourceExpr, prop.Name);
            var selectorExpr = Expression.Lambda(propExpr, sourceExpr);
            string method = isAscending ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { query.ElementType, selectorExpr.Body.Type };
            var orderByCallExpr = Expression.Call(typeof(Queryable), method, types, query.Expression, selectorExpr);
            return query.Provider.CreateQuery<TSource>(orderByCallExpr);
        }
    }    
