    var expr =
        Expression.Block(
            Expression.IfThen(
                Expression.Equal(Expression.Constant(1), Expression.Constant(1)),
                Expression.Throw(
                    Expression.New(typeof(DivideByZeroException))
                )
            ),
            Expression.Constant(1)
        );
    var lambda = Expression.Lambda<Func<int>>(expr);
    var result = lambda.Compile()();
