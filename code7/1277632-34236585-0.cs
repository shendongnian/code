      public static class ExpressionBuilder
        {
            private static readonly MethodInfo ToStringMethod = typeof(object).GetMethod("ToString");
            private static readonly MethodInfo StringContainsMethod = typeof(string).GetMethod("Contains");
    
            public static Func<T, object> Selector<T>(string prop)
            {
                var type = typeof(T);
                var param = Expression.Parameter(type);
                return Expression.Lambda<Func<T, object>>(Expression.Property(param, type.GetProperty(prop)), param).Compile();
            }
    
            public static Expression<Func<T, bool>> BuildFilterPredicate<T>(string q)
            {
                var query = Expression.Constant(q);
                var type = typeof(T);
                var lbdSelector = Expression.Parameter(type);
                var predicates = type.GetProperties().SelectMany(p => PredicateContainsBuilder(lbdSelector, p, query)).ToList();
                Expression body = predicates[0];
                body = predicates.Skip(1).Aggregate(body, Expression.OrElse);
                return Expression.Lambda<Func<T, bool>>(body, lbdSelector);
            }
    
            private static IEnumerable<MethodCallExpression> PredicateContainsBuilder(Expression lbdSelector, PropertyInfo prop, Expression query)
            {
    
                if (prop.PropertyType.IsClass)
                    return new List<MethodCallExpression> { Expression.Call(Expression.Call(Expression.Property(lbdSelector, prop), ToStringMethod), StringContainsMethod, query) };
    
                var properties = prop.PropertyType.GetProperties();
                return properties.Select(p => Expression.Call(Expression.Call(Expression.Property(lbdSelector, p), ToStringMethod), StringContainsMethod, query)).ToList();
            }
        }
