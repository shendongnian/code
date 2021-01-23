    public static void Sample<TData, TValue>(Expression<Func<TData, TValue>> expression) 
    {
        var body = expression.Body;
        var par1 = expression.Parameters[0];
        MemberExpression member = body as MemberExpression;
        if (member == null)
        {
            throw new ArgumentException();
        }
        if (member.Expression != par1)
        {
            throw new ArgumentException();
        }
        // Success
    }
