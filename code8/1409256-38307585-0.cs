    class Program
    {
        public static void ConsumeExpressions(List<Expression> exprs)
        {
            var consumerMethod = typeof(Program).GetMethod("ConsumeExpression", BindingFlags.Public | BindingFlags.Static);
            foreach (var expr in exprs)
            {
                var methodInfo = expr.GetType().GetGenericArguments()[0].GetMethod("Invoke");
                var inType = methodInfo.GetParameters()[0].ParameterType;
                var outType = methodInfo.ReturnType;
                var genericMethod = consumerMethod.MakeGenericMethod(inType, outType);
                genericMethod.Invoke(null, new object[] { expr });
            }
        }
        public static void ConsumeExpression<TInType, TOutType>(Expression<Func<TInType, TOutType>> expr)
        {
            Console.WriteLine("in: {0}, out: {1}", typeof(TInType).Name, typeof(TOutType).Name);
        }
        static void Main(string[] args)
        {
            ConsumeExpressions(new List<Expression>
            {
                (Expression<Func<int, string>>)(i => ""),
                (Expression<Func<string, int>>)(s => 0)
            });
        }
    }
