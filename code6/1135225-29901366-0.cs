        public IQueryable<T> SetDateCompare<T>(IQueryable<T> OriginalQuery, Expression<Func<T, DateTime>> getDateFunc, DateTime ComparisonDate, bool isGreaterThan = true)
    where T : class
        {
            if (isGreaterThan)
            {
                
                Expression left = Expression.Call(getDateFunc.Body, typeof(DateTime).GetMethod("get_Day"));
                Expression right = Expression.Constant(ComparisonDate.Day, typeof(int));
                Expression res = Expression.GreaterThan(left, right);
                var whereCallLambda = Expression.Lambda<Func<T, bool>>(Expression.GreaterThanOrEqual(left, right), getDateFunc.Parameters.Single());
                MethodCallExpression whereCall = Expression.Call(typeof(Queryable),
                                                                        "Where",
                                                                        new Type[] { OriginalQuery.ElementType },
                                                                        OriginalQuery.Expression,
                                                                        whereCallLambda);
                OriginalQuery = OriginalQuery.Provider.CreateQuery<T>(whereCall);
            }
           
            return OriginalQuery;
        }
