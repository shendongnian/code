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
                            argumentsExpressions.Add(Expression.Convert(indexedAcccess, paramArguments[i]));
                        }
                        var newExpr = Expression.New(cInfo, argumentsExpressions);
                        _constructors [cInfo] = ctor = Expression.Lambda(Expression.Convert(newExpr, typeof(Object)), new[] { parameterExpression }).Compile() as Func<Object[], Object>;
                    }
                }
            }
            return ctor;
        }
    }
