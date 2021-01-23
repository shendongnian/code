    Expression<Func<YourModel, object>> boxed = m => m.IsAnAirplane;
    var unboxed = (Expression<Func<YourModel, bool>>)StripConvert(m);
    // ...
    public static Expression StripConvert<T>(Expression<Func<T, object>> source)
    {
        Expression result = source.Body;
        // use a loop in case there are nested Convert calls for some crazy reason
        while ((result.NodeType == ExpressionType.Convert)
               || (result.NodeType == ExpressionType.ConvertChecked))
        {
            result = ((UnaryExpression)result).Operand;
        }
        return Expression.Lambda(result, source.Parameters);
    }
