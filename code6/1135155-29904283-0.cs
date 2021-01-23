    Expression<Func<DateTime, DateTime, bool>> ymdCompareLess = (v1, v2) => v1.Day <= v2.Day && v1.Month <= v2.Month && v1.Year <= v2.Year;
    Expression<Func<DateTime, DateTime, bool>> ymdCompareGreater = (v1, v2) => v1.Day >= v2.Day && v1.Month >= v2.Month && v1.Year >= v2.Year;
    public IQueryable<T> SetDateCompare<T>(IQueryable<T> OriginalQuery, Expression<Func<T, DateTime>> QueryProperty, DateTime ComparisonDate, bool isGreaterThan = true)
            where T : class
    {
        LambdaExpression comparisonExpression = isGreaterThan ? ymdCompareGreater : ymdCompareLess;
        var replaceVisitor = new ReplaceVisitor(
            comparisonExpression.Parameters.ToArray(),
            new[] { QueryProperty.Body, Expression.Constant(ComparisonDate) }
            );
        var whereBody = replaceVisitor.Visit(comparisonExpression.Body);
        var whereClause = Expression.Lambda<Func<T, bool>>(whereBody, QueryProperty.Parameters);
        return OriginalQuery.Where(whereClause);
    }
    private class ReplaceVisitor : ExpressionVisitor
    {
        Expression[] _from;
        Expression[] _to;
        public ReplaceVisitor(Expression[] from, Expression[] to)
        {
            this._from = from;
            this._to = to;
        }
        public override Expression Visit(Expression node)
        {
            var idx = Array.IndexOf(_from, node);
            if (idx > -1)
            {
                return _to[idx];
            }
            return base.Visit(node);
        }
    }
