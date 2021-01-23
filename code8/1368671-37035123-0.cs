    using System;
    using System.Linq;
    using System.Linq.Expressions;
    
    public static class QueryableUtils
    {
        public static IQueryable<T> WhereIn<T>(this IQueryable<T> source, Expression<Func<T, DateTime>> dateSelector, DateTime startDate, DateTime endDate)
        {
            var predicate = Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    Expression.GreaterThanOrEqual(dateSelector.Body, Expression.Constant(startDate)),
                    Expression.LessThan(dateSelector.Body, Expression.Constant(endDate))
                ),
                dateSelector.Parameters[0]);
            return source.Where(predicate);
        }
    }
