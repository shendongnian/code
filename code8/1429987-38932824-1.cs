    public interface ISomeService 
    {
         // Interface members
    }
    public class SomeService : ISomeService
    {
        public SomeService(DbContext dbContext)
        {
             DbContext = dbContext;
        }
    
        private DbContext DbContext { get; }
    }
