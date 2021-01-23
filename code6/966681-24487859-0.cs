    public class LookupRepository<T> : ILookupRepository<T>
    {
        public IDbContext _context;
        public LookupRepository(IDbContext context)
        {
           context = _context;
        }
        public IEnumerable<T> GetLookupData()
        {
            return _context.Set<T>();
        }
    }
