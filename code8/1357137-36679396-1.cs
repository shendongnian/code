     public abstract class RepositoryBase<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class , IEntity<TId>, IRetrievableEntity<TEntity, TId>
        where TId : struct
    {
        protected readonly IRepositoryContext RepositoryContext;
        protected readonly DbContext Context;
        protected RepositoryBase(IRepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public DbSet<TEntity> Data { get { return RepositoryContext.DbContext.Set<TEntity>(); }
        public TEntity Get(TId id)
        {
            return Data.Find(id);
        }
        public virtual IList<TEntity> GetAll()
        {
            return Data.ToList();
        }
        public virtual TEntity Save(TEntity entity)
        {
            try
            {
                var state = entity.Id.Equals(default(TId)) ? EntityState.Added : EntityState.Modified;
                RepositoryContext.DbContext.Entry(entity).State = state;
                RepositoryContext.Save();
                return entity;
            }
            catch (DbEntityValidationException e)
            {
                throw ValidationExceptionFactory.GetException(e);
            }
        }
        public virtual void Delete(TEntity entity)
        {
            if (entity == null) return;
            Data.Remove(entity);
            Context.SaveChanges();
        }
        public void Commit()
        {
            RepositoryContext.Save();
        }
        public IList<TEntity> Get(Expression<Func<TEntity, bool>> criteria)
        {
            return Data.Where(criteria).ToList();
        }
        // some other base stuff here
    }
