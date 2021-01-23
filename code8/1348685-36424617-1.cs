    public static class MathOps
    {
        public static Expression<Func<int, int, int, int>> SumAndDivide { get; } = (a, b, c) => (a + b) / c;
    }
    public static class ExpressionExtensions
    {
        public static object ExecuteAndLog<TExpr>(this TExpr expr, object args)
            where TExpr : LambdaExpression
        {
            Contract.Requires(expr != null);
            Contract.Requires(args != null);
            IEnumerable<PropertyInfo> argsProperties =
                args.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            Contract.Assert(expr.Parameters.Count == argsProperties.Count());
            Delegate compiledDelegate = expr.Compile();
            string exprAsText = expr.Body.ToString();
            string replacedExprAsText = (string)exprAsText.Clone();
            List<object> delegateArgs = new List<object>();
            foreach (PropertyInfo property in argsProperties)
            {
                delegateArgs.Add(property.GetValue(args));
                replacedExprAsText = replacedExprAsText.Replace(property.Name, property.GetValue(args)?.ToString());
            }
            object result = compiledDelegate.DynamicInvoke(delegateArgs.ToArray());
            string logMessage = $"result = {exprAsText} ({result} = {replacedExprAsText})";
            // Replace this with your logger
            Trace.WriteLine(logMessage);
            return result;
        }
    }
