    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IXXDbContext dataContext;
        private readonly DbSet<TEntity> dbset;
        public Repository(IDatabaseFactory databaseFactory) {
            if (databaseFactory == null) {
                throw new ArgumentNullException("databaseFactory", "argument is null");
            }
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<TEntity>();
        }
        public ISefeViewerDbContext DataContext {
            get { return (dataContext ?? (dataContext = DatabaseFactory.Get()));
        }
        
        public virtual TEntity GetById(Guid id){
            return dbset.Find(id);
        }
    ....
