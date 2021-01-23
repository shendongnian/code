    public class GenericRepository<TEntity> where TEntity : class
    {
        internal DbContext context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual TEntity Insert(TEntity entity)
        {
            dbSet.Add(entity);
            return entity;
        }
    }
