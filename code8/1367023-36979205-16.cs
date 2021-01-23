    public class AppBackendRepository
    {
        private IDbContext _dbContext;
        
        // With injection.
        public AppBackendRepository(IDbContext context)
        {
            _dbContext = context;
        }
    
        public List<Student> Get()
        {
            // Only active...
            return _dbContext.Students.Where(x => x.Active).ToList();
        }
    }
