    public static T Validate<T>(this Expression<Func<T>> argument)
    {
        var lambda = (LambdaExpression)argument;
        MemberExpression memberExpression;
        if (lambda.Body is UnaryExpression)
        {
            var unaryExpression = (UnaryExpression)lambda.Body;
            memberExpression = (MemberExpression)unaryExpression.Operand;
        }
        else
        {
            memberExpression = (MemberExpression)lambda.Body;
        }
        string name = memberExpression.Member.Name;
        Delegate d = lambda.Compile();
        return (T)d.DynamicInvoke();
    }
