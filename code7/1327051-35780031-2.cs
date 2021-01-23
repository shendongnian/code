    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
    {
        public virtual TEntity GetById(TId id)
        {
            return context.Set<TEntity>().Find(id);
        }
    }
