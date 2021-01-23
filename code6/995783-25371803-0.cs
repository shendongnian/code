    public GenericRepository(MyDbContext context) {
        _context = context;
        _dbSet = context.Set<T>();
    }
    //Would like to limit object to be of type BaseEntity or ICollection<BaseEntity>
    public IQueryable<TEntity> Get(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = _dbSet.AsQueryable();
        foreach (var include in includeProperties){
            query = query.Include(include);
        }
        return query;
    }
}
