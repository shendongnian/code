    public static String GenerateReference<T>(Expression<Action<T>> expression)
    {
        var member = expression.Body as MethodCallExpression;
    
        if (member != null)
            return member.Method.Name;
    
        throw new ArgumentException("Expression is not a method", "expression");
    }
    GenerateReference<MyClass>(c => c.SayHello(null));
