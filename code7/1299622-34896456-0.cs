    public class ExpressionGetter<T>
        {
            public static Expression<Func<T, Object>> Get(PropertyInfo pInfo)
            {
                ParameterExpression parameter = Expression.Parameter(typeof(T));
                MemberExpression property = Expression.Property(parameter, pInfo);
                Type funcType = typeof(Func<,>).MakeGenericType(typeof(T), typeof(object));
    
                //next line fails: can't convert int to object
    
                LambdaExpression lambda;
                if (typeof (T).IsClass == false && typeof (T).IsInterface == false)
                    lambda = Expression.Lambda(funcType, Expression.Convert(property, typeof (Object)), parameter);
                else
                    lambda = Expression.Lambda(funcType, property, parameter);
                
                return (Expression<Func<T, object>>)lambda;
            }
        }
