    public class UnitOfWork : IUnitOfWork, IDisposable
        {
            public DbContext Database { get; private set; }
    
            public UnitOfWork(DbContext dbContext)
            {
                Database = dbContext;
            }
    
            public void SaveChanges()
            {
                Database.SaveChanges();
            }
    
            public void Dispose() 
            {
                Database.Dispose();
            }
        }
