    public class UnitOfWork : IUnitOfWork
    {
        ProjectDbContext context;
        public UnitOfWork() {
            context = new ProjectDbContext();    
        }
        public IQueryable<T> Query<T>(Expression<Func<bool, t>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }
        public void Add<T>(T entity)
        {
            context.Set<T>().Add(entity);
        }
    
        public int SaveChanges()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
    
    public class UnitOfWorkFactory
    {
        Lazy<UnitOfWork> lazyUOW = new Lazy<UnitOfWork>(() => new UnitOfWork());
        public UnitOfWork Create() 
        {
            // having the DI initialise as Singleton isn't enough.
            return lazyUOW.Value;
        }
    }
    
    public class Repository<T> : IRepository<T>
    {
        private readonly IUnitOfWork uow;
    
        public Repository(IUnitOfWork uow)
        {
            uow = uow;
        }
    
        public void Add(T entity)
        {
            uow.Add(entity);
        }
        public List<T> AllBySomePredicate(Expression<Func<bool, T>> predicate)
        {
            return uow.Query(predicate).ToList();
        }  
    }
    
    public class RepositoryFactory : IRepositoryFactory 
    {
        public Create<T>(UnitOfWork uow)
        {
            new Repistory<T>(uow);
        }
    }
