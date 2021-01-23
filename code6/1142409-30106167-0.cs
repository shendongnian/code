    private static void TestMethodCallCompilation()
    {
        var methodInfo = typeof(Program).GetMethod("GimmeExpression", 
            BindingFlags.NonPublic | BindingFlags.Static);
    
        var lambdaExpression = Expression.Lambda<Func<bool>>(Expression.Constant(true));
    
        var methodCallExpression = 
          Expression.Call(null, methodInfo, Expression.Constant(lambdaExpression));
    
        var wrapperLambda = Expression.Lambda(methodCallExpression);
        wrapperLambda.Compile().DynamicInvoke();
    }
    
    private static void GimmeExpression(Expression<Func<bool>> exp)
    {
        Console.WriteLine(exp.GetType());
        Console.WriteLine("Compiling and executing expression...");
        Console.WriteLine(exp.Compile().Invoke());
    }
