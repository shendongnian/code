        public static IQueryOver<TRoot, TSubType> WhereLike<TRoot, TSubType>(this IQueryOver<TRoot, TSubType> query, Expression<Func<TSubType, object>> thisLike, Expression<Func<TSubType, object>> likeThis)
        {
            var propName1 = ExpressionProcessor.FindMemberExpression(thisLike.Body);
            var propName2 = ExpressionProcessor.FindMemberExpression(likeThis.Body);
            query.Where(NHibernate.Criterion.Expression.Sql(string.Format(" {0} LIKE '%' + {1} + '%' ", propName1, propName2)));
            return query;
        }
