    public static class QueryableExtension
    {
        public static object Build<Tobject>(this Tobject source, string propertyName)
        {
            var propInfo = typeof(Tobject).GetProperty(propertyName);
            var parameter = Expression.Parameter(typeof(Tobject), "x");
            var property = Expression.Property(parameter, propInfo);
            var delegateType = typeof(Func<,>)
                               .MakeGenericType(typeof(Tobject), propInfo.PropertyType);
            var lambda = GetExpressionLambdaMethod()
                            .MakeGenericMethod(delegateType)
                            .Invoke(null, new object[] { property, new[] { parameter } });
            return lambda;
        }
        public static MethodInfo GetExpressionLambdaMethod()
        {
           return typeof(Expression)
                         .GetMethods()
                         .Where(m => m.Name == "Lambda")
                         .Select(m => new
                         {
                             Method = m,
                             Params = m.GetParameters(),
                             Args = m.GetGenericArguments()
                         })
                         .Where(x => x.Params.Length == 2
                                     && x.Args.Length == 1
                                     )
                         .Select(x => x.Method)
                         .First();
        }
    }
