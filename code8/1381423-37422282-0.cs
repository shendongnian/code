    var block = Expression.Block(
                        new ParameterExpression[] { vars, resultvar }, //variables
                        Expression.Assign(vars, Expression.Constant(default(int))),
                        Expression.Assign(resultvar, call),
                        Expression.Assign(pOutput, Expression.Convert(vars, typeof(int?))),
                        resultvar);
