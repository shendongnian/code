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
            return _dbContext.Students.ToList();
        }
    }
