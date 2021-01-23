    private static IEnumerable<object> GetArguments(MethodCallExpression body)
    {
        return body.Arguments.Select(
            expression => Expression.Lambda<Func<object>>(
                Expression.Convert(expression, typeof(object))).Compile()());
    }
