    public static string GetName<TResult>(Expression<Func<TResult>> exp)
    {
        return GetName(exp != null ? exp.Body as MethodCallExpression : null);
    }
    public static string GetName(Expression<Action> exp)
    {
        return GetName(exp != null ? exp.Body as MethodCallExpression : null);
    }
    private static string GetName(MethodCallExpression mce)
    {
        if (mce == null)
        {
            throw new ArgumentNullException();
        }
        return mce.Method.Name;
    }
