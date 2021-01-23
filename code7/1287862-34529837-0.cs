    public class OrderByData
        {
            public string PropertyName { get; set; }
        }
        public static class ExpressionBuilder
        {
            public static Expression<Func<T, string>> GetExpression<T>(OrderByData filter)
            {
    
                ParameterExpression param = Expression.Parameter(typeof(T), "t");
                Expression exp = GetExpression<T>(param, filter);
                return Expression.Lambda<Func<T, string>>(exp, param);
            }
    
            private static Expression GetExpression<T>(ParameterExpression param, OrderByData filter)
            {
                MemberExpression member = Expression.Property(param, filter.PropertyName);
                return member;
            }
        }
