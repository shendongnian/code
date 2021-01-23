    public static class QueryExtention {
        public static IQueryOver<E, F> WhereStringIsNullOrEmpty<E, F>(this IQueryOver<E, F> query, Expression<Func<E, object>> expression) {
            var property = Projections.Property(expression);
            var criteria = Restrictions.Or(Restrictions.IsNull(property),
                                           Restrictions.Eq(property, string.Empty));
            return query.Where(criteria);
        }
    }
