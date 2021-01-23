    var variable = Expression.Variable(typeof(int));
    var lambda = Expression.Lambda<Func<int>>(
        Expression.Block(
            new[] { variable }, 
            Expression.Assign(variable, Expression.Constant(1)), 
            variable)); // With lambda expressions, there is an implicit
                        // return of the last value "loaded" on the stack
