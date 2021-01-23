    // should not be called Async
    public IEnumerable<TEntity> RetrieveCollectionAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var query = DataContext.Set<TEntity>().AsQueryable();
            if (predicate != null)
                query = query.Where(predicate);
            return query;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
            throw ex; // should be: throw;
        }
    }
