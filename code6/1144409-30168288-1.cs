    public static class DecimalClipper<T>
    {
        public static readonly Func<decimal, T> Clip;
        static DecimalClipper()
        {
            ParameterExpression value = Expression.Parameter(typeof(decimal), "value");
            Expression<Func<decimal, T>> lambda;
            if (typeof(T) == typeof(decimal))
            {
                lambda = Expression.Lambda<Func<decimal, T>>(value, value);
            }
            else if (typeof(T) == typeof(float) || typeof(T) == typeof(double))
            {
                lambda = Expression.Lambda<Func<decimal, T>>(Expression.Convert(value, typeof(T)), value);
            }
            else
            {
                T min = (T)typeof(T).GetField("MinValue", BindingFlags.Static | BindingFlags.Public).GetValue(null);
                Expression minT = Expression.Constant(min);
                Expression minDecimal = Expression.Constant(Convert.ToDecimal(min));
                T max = (T)typeof(T).GetField("MaxValue", BindingFlags.Static | BindingFlags.Public).GetValue(null);
                Expression maxT = Expression.Constant(max);
                Expression maxDecimal = Expression.Constant(Convert.ToDecimal(max));
                UnaryExpression cast = Expression.Convert(value, typeof(T));
                ConditionalExpression greaterThanOrEqual = Expression.Condition(Expression.GreaterThanOrEqual(value, maxDecimal), maxT, cast);
                ConditionalExpression lesserThanOrEqual = Expression.Condition(Expression.LessThanOrEqual(value, minDecimal), minT, greaterThanOrEqual);
                lambda = Expression.Lambda<Func<decimal, T>>(lesserThanOrEqual, value);
            }
            Clip = lambda.Compile();
        }
    }
    public static class DecimalEx
    {
        public static T Clip<T>(this decimal value)
        {
            return DecimalClipper<T>.Clip(value);
        }
    }
