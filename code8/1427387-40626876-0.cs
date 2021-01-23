    public interface IRepository<TEntity>
    {
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddAll(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveAll(IEnumerable<TEntity> entities);
    }
