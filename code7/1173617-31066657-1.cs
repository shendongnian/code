    MethodInfo select = (from x in typeof(Queryable).GetMethods()
                        where x.Name == "Select" && x.IsGenericMethod
                        let gens = x.GetGenericArguments()
                        where gens.Length == 2
                        let pars = x.GetParameters()
                        where pars.Length == 2 && 
                            pars[0].ParameterType == typeof(IQueryable<>).MakeGenericType(gens[0]) &&
                            pars[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(gens))
                        select x).Single().MakeGenericMethod(typeof(SomeClass), typeof(string));
    MethodCallExpression select2 = Expression.Call(null, select, Expression.Constant(queryable), lambda);
    IQueryProvider provider = queryable.Provider;
    IQueryable<string> q3 = provider.CreateQuery<string>(select2);
