    public static class QueryableExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, ConvertableExpression<T> expr)
        {
            Expression queryExpr = source.Expression;
            var exprBody = SkipConverts(expr.Expression.Body);
            var lambda = Expression.Lambda(exprBody, expr.Expression.Parameters);
            var quote = Expression.Quote(lambda);
            queryExpr = Expression.Call(typeof(Queryable), "OrderBy", new[] { source.ElementType, exprBody.Type }, queryExpr, quote);
            return (IOrderedQueryable<T>)source.Provider.CreateQuery(queryExpr);
        }
        private static Expression SkipConverts(Expression expression)
        {
            Expression result = expression;
            while (result.NodeType == ExpressionType.Convert || result.NodeType == ExpressionType.ConvertChecked)
                result = ((UnaryExpression)result).Operand;
            return result;
        }
    }
