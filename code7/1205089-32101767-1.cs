    public async virtual Task<IList<T>> GetListAsync(IDbContext context,
                                                     Expression<Func<T, bool>> where,
                                                     IOrderByClause<T>[] orderBy = null,
                                                     params Expression<Func<T, object>>[] navigationProperties)
    {
        using (await context.ContextLock.LockAsync())
        {
            IList<T> list = await GetListQuery(context, where, orderBy, navigationProperties).ToListAsync();
            return list;
        }
    }
