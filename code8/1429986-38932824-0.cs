    public class SomeService
    {
        public SomeService(DbContext dbContext)
        {
             DbContext = dbContext;
        }
    
        public DbContext DbContext { get; }
    }
