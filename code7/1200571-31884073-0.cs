    public static Func<Object[], Object> CreateConstructor<T>(this T @this, params Type[] paramArguments)
        {
            ConstructorInfo cInfo = typeof(T).GetConstructor(paramArguments);
            if (cInfo == null)
                throw new NotSupportedException("Could not detect constructor having the coresponding parameter types");
            // compile the call
            var parameterExpression = Expression.Parameter(typeof(object[]), "arguments");
            List<Expression> argumentsExpressions = new List<Expression> ();
            for (var i = 0; i < paramArguments.Length; i++ )
            {
                var indexedAcccess = Expression.ArrayIndex (parameterExpression, Expression.Constant (i));
                argumentsExpressions.Add (Expression.Convert (indexedAcccess, paramArguments [i]));
            }
            var newExpr = Expression.New(cInfo, argumentsExpressions);
            return Expression.Lambda(Expression.Convert(newExpr, typeof(Object)), new [] {parameterExpression}).Compile () as Func<Object[], Object>;
        }
