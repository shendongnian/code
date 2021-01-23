    public interface IRepositoryContext
    {
        DbContext DbContext { get; }
        /// <summary>
        /// Commit data.
        /// </summary>
        void Save();
    }
    public class RepositoryContext : IRepositoryContext
    {
        private readonly DbContext _dbContext;
        public RepositoryContext(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DbContext DbContext { get { return _dbContext; } }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
