    public static IQueryable<TEntity> PreferLocal<TEntity>(this DbSet<TEntity> dbSet, 
        Expression<Func<TEntity, bool>> predicate)
            where TEntity : class
    {
    	if (dbSet.Local.AsQueryable().Any(predicate))
    	{
    		return dbSet.Local.AsQueryable().Where(predicate);
    	}
    	return dbSet.Where(predicate);
    }
