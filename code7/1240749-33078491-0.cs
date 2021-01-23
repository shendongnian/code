    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _context;
    
        public Repository(DbContext context)
        {
            _context = context;
        }
        public IQueryable<TEntity> All
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }
    }
