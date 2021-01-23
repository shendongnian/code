    Expression<Func<int>> inputExpression = () => 42;
    
    var newLambda = 
        Expression.Lambda<Func<object>>
        (
            Expression.Convert
            (
                Expression.Invoke(inputExpression), 
                typeof(object)
            )
        );
        
    Console.WriteLine(newLambda.Compile()()); // Prints 42.
