    public static class QueryableEx
    {
        public static IOrderedQueryable<TSource> OrderByEx<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, object>> keySelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException("keySelector");
            }
            // While the return type of keySelector is object, the "type" of 
            // keySelector.Body is the "real" type *or* it is a
            // Convert(body). We rebuild a new Expression with this "correct" 
            // Body (removing the Convert if present). The return type is
            // automatically chosen from the type of the keySelector.Body .
            Expression body = keySelector.Body;
            if (body.NodeType == ExpressionType.Convert)
            {
                body = ((UnaryExpression)body).Operand;
            }
            LambdaExpression keySelector2 = Expression.Lambda(body, keySelector.Parameters);
            Type tkey = keySelector2.ReturnType;
            MethodInfo orderbyMethod = (from x in typeof(Queryable).GetMethods()
                                        where x.Name == "OrderBy"
                                        let parameters = x.GetParameters()
                                        where parameters.Length == 2
                                        let generics = x.GetGenericArguments()
                                        where generics.Length == 2
                                        where parameters[0].ParameterType == typeof(IQueryable<>).MakeGenericType(generics[0]) && 
                                            parameters[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(generics[0], generics[1]))
                                        select x).Single();
            return (IOrderedQueryable<TSource>)source.Provider.CreateQuery<TSource>(Expression.Call(null, orderbyMethod.MakeGenericMethod(new Type[]
	        {
		        typeof(TSource),
		        tkey
	        }), new Expression[]
	        {
		        source.Expression,
		        Expression.Quote(keySelector2)
	        }));
        }
    }
