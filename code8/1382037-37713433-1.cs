    public static class ExtentionMethods
    {
        public static IQueryable<T> WhereSpecial<T>(this IQueryable<T> queryable, Expression<Func<T,bool>> expression )
        {
            MyVisitor visitor = new MyVisitor();
            var newBody = visitor.Visit(expression.Body);
            expression = expression.Update(newBody, expression.Parameters);
            return queryable.Where(expression);
        }
    }
