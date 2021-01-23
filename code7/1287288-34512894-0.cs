    public static class PredicateHelper
    {
        public static Expression<Func<T, bool>> In<T>(this Expression<Func<T, int>> idSelector, IEnumerable<int> ids)
        {
            Expression body = null;
            foreach (var id in ids)
            {
                var operand = Expression.Equal(idSelector.Body, Expression.Constant(id));
                body = body == null ? operand : Expression.OrElse(body, operand);
            }
            return body != null ? Expression.Lambda<Func<T, bool>>(body, idSelector.Parameters) : null;
        }
    }
