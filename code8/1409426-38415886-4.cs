    public static IIncludableQueryable<TEntity, TProperty>
    ThenInclude<TEntity, TPreviousProperty, TProperty>
    (
        this IIncludableQueryable<TEntity, ICollection<TPreviousProperty>> source,
        Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath
    )
