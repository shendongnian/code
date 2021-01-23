    private static Expression NestedExpression(
        IEnumerable<Expression<Func<TEntity, bool>>> expressions, 
        int startIndex = 0)
    {
        var range = expressions.ToList();
        range.RemoveRange(0, startIndex);
        if (range.Count == 0)
            return Expression.Constant(-1);
        return Expression.Condition(
            range[0].Body, 
            Expression.Constant(startIndex), 
            NestedExpression(enumerable, ++startIndex));
        }
    }
