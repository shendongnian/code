    public static string GetMethodName<T>(this T instance, Expression<Action<T>> methodExpression)
    {
        if (methodExpression.Body is MethodCallExpression)
        {
            return ((MethodCallExpression)methodExpression.Body).Method.Name;
        }
        else
        {
            throw new ArgumentException(string.Format("Invalid method expression: {0}", methodExpression.Body));
        }
    }
