    public class UnitOfWork : IUnitOfWork
    {
        private readonly FooContext _dbContext;
        
        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    
        // Dispose method
    }
