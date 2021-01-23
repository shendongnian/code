    class Program
    {
        public static void ConsumeExpressions(List<LambdaExpression> exprs)
        {
            var consumerMethod = typeof(Program).GetMethod("ConsumeExpression", BindingFlags.Public | BindingFlags.Static);
            foreach (var expr in exprs)
            {
                var inType = expr.Parameters[0].Type;
                var outType = expr.ReturnType;
                var genericMethod = consumerMethod.MakeGenericMethod(inType, outType);
                genericMethod.Invoke(null, new object[] { expr });
            }
        }
        public static void ConsumeExpression<TInType, TOutType>(Expression<Func<TInType, TOutType>> expr)
        {
            Console.WriteLine("in: {0}, out: {1}, {2}", typeof(TInType).Name, typeof(TOutType).Name, expr);
        }
        static void Main(string[] args)
        {
            ConsumeExpressions(new List<LambdaExpression>
            {
                (Expression<Func<int, string>>)(i => ""),
                (Expression<Func<string, int>>)(s => 0)
            });
        }
    }
