    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private ForexDbContext dbContext;
        internal ForexDbContext DbContext
        {
            get { return dbContext ?? (dbContext = new ForexDbContext()); }
        }
        internal DbSet<T> Set<T>()
        where T : class
        {
            return DbContext.Set<T>();
        }
        public void Dispose()
        {
            if(dbContext == null) return;
            dbContext.Dispose();
            dbContext = null;
        }
        public void SaveChanges()
        {
            int result = DbContext.SaveChanges();
        }
        public ITransaction BeginTransaction()
        {
            return new EntityFrameworkTransaction(DbContext.BeginTransaction());
        }
    }
    
