    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
    //where TId : class
    {
    // Context setup...
    public virtual TEntity GetById(TId id)
    {
        return context.Set<TEntity>().SingleOrDefault(x => x.Id == id);
    }
}
