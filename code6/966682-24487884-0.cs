    public class GenericRepository<T> : ILookupRepository<T>
    {
        protected readonly IDbContext _context;
        
        protected GenericRepository(IDbContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetLookupData()
        {
            return _context.Set<T>();
        }
    }
