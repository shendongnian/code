    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IFooRepository _fooRepo;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
            // Each repo will share the db context:
            _fooRepo = new FooRepository(_dbContext);
        }
       
        public IFooRepository Foos
        {
            get
            {
                return _fooRepo;
            }
        }
        
        public void Complete()
        {
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
