    static void Main(string[] args)
    {
            var str = @"3*x^2+2/5*x+4";
            str = Transform(str);
            var param = Expression.Parameter(typeof (double), "x");
            var expression = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] {param}, null, str);
            var exp10 = expression.Compile().DynamicInvoke(10);
            Console.WriteLine(exp10);
    }
        public const string SupportedOps = "+-*/";//separators without ^
        private static string Transform(string expression)
        {
            //replace x^y with Math.Pow(x,y)
            var toBeReplaced = expression.Split(SupportedOps.ToCharArray()).Where(s => s.Contains("^"));
            var result = expression;
            return toBeReplaced.Aggregate(expression, (current, str) => current.Replace(str, string.Format("Math.Pow({0})", str.Replace('^', ','))));
            //OR
            //foreach (var str in toBeReplaced)
            //{
            //    result =result.Replace(str, string.Format("Math.Pow({0})", str.Replace('^', ',')));
            //}
            //return result;    
    }
