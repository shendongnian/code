    public static IQueryable<IRetrieveGuid> SearchByRetrieveGuid<IRetrieveGuid>(this IQueryable<IRetrieveGuid> queryable, SearchModel search)
        {
            var paramLambda = Expression.Parameter(typeof (IRetrieveGuid));
            var columnLambda = Expression.Property(paramLambda, "retrieveguid");
            var lambda = Expression.Lambda<Func<IRetrieveGuid, bool>>(
                Expression.Equal(columnLambda, Expression.Call(Expression.Convert(Expression.Constant(search.RetrieveGuid), typeof (object)), typeof (object).GetMethod("ToString"))), paramLambda);
            return queryable.Where(lambda);
        }
