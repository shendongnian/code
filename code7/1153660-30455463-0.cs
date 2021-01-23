        MethodInfo selectQueryable = typeof(Queryable)
                    .GetMethods()
                    .Where(method => method.Name == "Select")
                    .Select(method => new { M = method, P = method.GetParameters() })
                    .Where(x => x.P.Length == 2
                        && x.P[0].ParameterType.IsGenericType
                        && x.P[0].ParameterType.GetGenericTypeDefinition() == typeof(IQueryable<>)
                        && x.P[1].ParameterType.IsGenericType
                        && x.P[1].ParameterType.GetGenericTypeDefinition() == typeof(Expression<>))
                    .Select(x => new { x.M, A = x.P[1].ParameterType.GetGenericArguments() })
                    .Where(x => x.A.Length == 1
                        && x.A[0].IsGenericType
                        && x.A[0].GetGenericTypeDefinition() == typeof(Func<,>))
                    .Select(x => x.M)
                    .Single()
                    .MakeGenericMethod(t,typeof(Purchases));
        var s = selectQueryable.Invoke(null, new[] { dbSet, lambda });
