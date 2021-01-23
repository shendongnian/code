            // Define the variable at the top of the block 
            // when we are returning something
            if (variableExpression != null)
            {
                block = Expression.Block(new[] { variableExpression }, methodBodyElements);
            }
            else
            {
                block = Expression.Block(methodBodyElements);
            }
            Expression<T> wrapperLambda = Expression<T>.Lambda<T>(block, parameterExpressions);
            return wrapperLambda.Compile();
