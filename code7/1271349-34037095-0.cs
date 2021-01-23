    public static void WriteToConsole<TObj, TProperty>(TObj obj, Expression<Func<TObj, TProperty>> expression)
    {
        MemberExpression memberExpr = (MemberExpression)expression.Body;
        string memberName = memberExpr.Member.Name;
        TProperty value = expression.Compile().Invoke(obj);
        Console.WriteLine($"{memberName}: {value}");
    }
