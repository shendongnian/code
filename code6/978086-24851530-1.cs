        public static IQueryable<T> WhereEx<T>(this IQueryable<T> q, string Field, string Operator, string Value)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, Field);
            var val = Expression.Constant(Value);
            var body = Expression.Equal(prop, val);
            var exp = Expression.Lambda<Func<T, bool>>(body, param);
            return System.Linq.Queryable.Where(q, exp);
        }
