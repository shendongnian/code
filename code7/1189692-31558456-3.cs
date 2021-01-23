    Expression<Func<int>> inputExpression = () => 42;
    var newLambda = 
      Expression.Lambda<Func<object>>
      (
        Expression.Convert(inputExpression.Body, typeof(object))
      );
    Console.WriteLine(newLambda.Compile()()); // Prints 42.
