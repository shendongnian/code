    public static IQueryable<int> WithZeros(this IQueryable<int> list)
    {
        var expr = list.Expression as MethodCallExpression;
        var constantExpr = expr.Arguments.OfType<ConstantExpression>().First(x => x.Value is IEnumerable<int>);
        var origDataSource = constantExpr.Value as IEnumerable<int>;
        return origDataSource.AsQueryable();
    }
