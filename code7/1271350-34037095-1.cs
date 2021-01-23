    public static void WriteToConsole<TObj, TProperty>(TObj obj, Expression<Func<TObj, TProperty>> expression)
    {
        MemberExpression memberExpr = (MemberExpression)expression.Body;
        string memberName = memberExpr.Member.Name;
        Func<TObj, TProperty> compiledDelegate = expression.Compile();
        TProperty value = compiledDelegate(obj);
        Console.WriteLine($"{memberName}: {value}");
    }
