    public class AppBackendRepository
    {
        public List<Student> Get()
        {
            using (var context = DbContextFactory.GenerateContext())
            {
                return context .Students.ToList();
            }
        }
    }
    public interface IDbContextFactory
    {
        /// <summary>
        /// Creates a new context.
        /// </summary>
        /// <returns></returns>
        IDbContext GenerateContext();
        /// <summary>
        /// Returns the previously created context.
        /// </summary>
        /// <returns></returns>
        IDbContext GetCurrentContext();
    }
    public class DbContextFactory : IDbContextFactory
    {
        private IDbContext _context;
        public IDbContext GenerateContext()
        {
            _context = new DbContext();
            return _context;
        }
        public IDbContext GetCurrentContext()
        {
            if (_context == null)
                _context = GenerateContext();
            return _context;
        }
    }
