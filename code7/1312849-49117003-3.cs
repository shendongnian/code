    public static IQueryable<TEntity> FilterByIDs<TEntity>(
        this IQueryable<TEntity> query, int[] ids)
        where TEntity : class, IBase
    {
        if (ids == null || !ids.Any(x => x > 0 && x != int.MaxValue)) { return query; }
        return query.AsExpandable().Where(BuildIDsPredicate<TEntity>(ids));
    }
    private static Expression<Func<TEntity, bool>> BuildIDsPredicate<TEntity>(
        IEnumerable<int> ids)
        where TEntity : class, IBase
    {
        return ids.Aggregate(
            PredicateBuilder.New<TEntity>(false),
            (c, id) => c.Or(p => p.ID == id));
    }
