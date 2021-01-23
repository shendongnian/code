      public IQueryable<T> SetDateCompare<T>(IQueryable<T> OriginalQuery, Expression<Func<T, DateTime>> getDateFunc, DateTime? ComparisonDate, bool isGreaterThan = true)
        where T : class
        {
                
                Expression right = Expression.Constant(ComparisonDate, typeof(DateTime?));
                var RightFunc = Expression.Call(typeof(DbFunctions), "TruncateTime", null, right);
                //Expression left = Expression.Call(getDateFunc.Body, typeof(DateTime).GetMethod("get_Day"));
                //Expression res = Expression.GreaterThan(left, right);
                
                Expression FuncToExec = isGreaterThan ?
                    MyGreaterThanOrEqual(getDateFunc.Body, RightFunc) :
                     MyLessThanOrEqual(getDateFunc.Body, RightFunc);
                var whereCallLambda = Expression.Lambda<Func<T, bool>>(FuncToExec, getDateFunc.Parameters.Single());
                MethodCallExpression whereCall = Expression.Call(typeof(Queryable),
                                                                        "Where",
                                                                        new Type[] { OriginalQuery.ElementType },
                                                                        OriginalQuery.Expression,
                                                                        whereCallLambda);
                OriginalQuery = OriginalQuery.Provider.CreateQuery<T>(whereCall);
           
            
            return OriginalQuery;
        }
