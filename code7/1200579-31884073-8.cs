    public static class ConstructorCallExcentions
    {
        private static Dictionary<ConstructorInfo, Func<Object[], Object>> _constructors = new Dictionary<ConstructorInfo,Func<object[],object>> ();
        private static object syncObject = new object();
        public static Func<Object[], Object> CreateConstructor<T>(this T @this, params Type[] paramArguments)
        {
            
            ConstructorInfo cInfo = typeof(T).GetConstructor(paramArguments);
            if (cInfo == null)
                throw new NotSupportedException("Could not detect constructor having the coresponding parameter types");
            Func<Object[], Object> ctor;
            if (false == _constructors.TryGetValue (cInfo, out ctor))
            {
                lock (_constructors)
                {
                    if (false == _constructors.TryGetValue (cInfo, out ctor))
                    {
                        // compile the call
                        var parameterExpression = Expression.Parameter(typeof(object[]), "arguments");
                        List<Expression> argumentsExpressions = new List<Expression>();
                        for (var i = 0; i < paramArguments.Length; i++)
                        {
                            var indexedAcccess = Expression.ArrayIndex(parameterExpression, Expression.Constant(i));
                            // it is NOT a reference type!
                            if (paramArguments [i].IsClass == false && paramArguments [i].IsInterface == false)
                            {
                                // it might be the case when I receive null and must convert to a structure. In  this case I must put default (ThatStructure).
                                var localVariable = Expression.Variable(paramArguments[i], "localVariable");
                                var block = Expression.Block (new [] {localVariable},
                                        Expression.IfThenElse (Expression.Equal (indexedAcccess, Expression.Constant (null)),
                                            Expression.Assign (localVariable, Expression.Default (paramArguments [i])),
                                            Expression.Assign (localVariable, Expression.Convert(indexedAcccess, paramArguments[i]))
                                        ),
                                        localVariable
                                    );
                                argumentsExpressions.Add(block);
                            }
                            else
                                argumentsExpressions.Add(Expression.Convert(indexedAcccess, paramArguments[i])); // do a convert to that reference type. If null, the convert is FINE.
                        }
                        // check if parameters length maches the length of constructor parameters!
                        var lengthProperty = typeof (Object[]).GetProperty ("Length");
                        var len = Expression.Property (parameterExpression, lengthProperty);
                        var invalidParameterExpression = typeof(ArgumentException).GetConstructor(new Type[] { typeof(string) });
                        var checkLengthExpression = Expression.IfThen (Expression.NotEqual (len, Expression.Constant (paramArguments.Length)),
                            Expression.Throw(Expression.New(invalidParameterExpression, Expression.Constant ("The length does not match parameters number")))
                            );
                        var newExpr = Expression.New(cInfo, argumentsExpressions);
                        var finalBlock = Expression.Block(checkLengthExpression, Expression.Convert(newExpr, typeof(Object)));
                        _constructors[cInfo] = ctor = Expression.Lambda(finalBlock, new[] { parameterExpression }).Compile() as Func<Object[], Object>;
                    }
                }
            }
            return ctor;
        }
    }
