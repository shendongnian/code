    public interface IDataContext {
        DbSet<Repository> Repository { get; }
        DbContextTransaction BeginTransaction();
    }
    public class DataContextAdapter {
        private readonly DataContext _dataContext;
        public DataContextAdapter(DataContext dataContext) {
            _dataContext = dataContext;
        }
        public DbSet<Repository> Repository { get { return _dataContext.Repository; } }
        public DbContextTransaction BeginTransaction() {
            return _dataContext.Database.BeginTransaction();
        }
    }
