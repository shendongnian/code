       public abstract class RepositoryBase<T, TDbContext> : IRepository<T> where T : class, IDomainEntity where TDbContext : DbContext
        {
            private readonly DbSet<T> _dbset;
            private readonly IAmbientDbContextLocator _contextLocator;
    
            protected RepositoryBase(IAmbientDbContextLocator ctxLocator)
            {
                if (ctxLocator == null) throw new ArgumentNullException(nameof(ctxLocator));
                _contextLocator = ctxLocator;
                _dbset = _contextLocator.Get<TDbContext>.Set<T>();
            }
    
            protected DbSet<T> DbSet { get { return _dbset; } }
            public T Get(Guid id)
            {
                return DbSet.Find(id);
            }
        }
