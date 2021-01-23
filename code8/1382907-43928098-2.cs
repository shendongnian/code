    public abstract class SecureRepository<TInterface, TEntity> : IRepository<TInterface>
        where TEntity : class, new()
        where TInterface : class
    {
        protected DbSet<TEntity> DbSet;
        protected SecureRepository(DataContext dataContext)
        {
            DbSet = dataContext.Set<TEntity>();
        }
        public virtual IIncludableJoin<TInterface, TProperty> Join<TProperty>(Expression<Func<TInterface, TProperty>> navigationProperty)
        {
            return ((IQueryable<TInterface>)DbSet).Join(navigationProperty);
        }
        ...
    }
