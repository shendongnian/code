    public static MethodCallExpression Like(this ParameterExpression pe, string value)
    {
        var prop = Expression.Property(pe, pe.Name);
        return Expression.Call(typeof(SqlMethods), "Like", null, prop, Expression.Constant(value));
    }
