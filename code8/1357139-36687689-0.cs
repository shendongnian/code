    public interface IDbContextFactory
    {
        IDbContext GetContext();
    }
    
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IDbContext _context;
    
        public DbContextFactory()
        {
            _context = new MyDbContext("ConnectionStringName");
        }
    
        public IDbContext GetContext()
        {
            return _context;
        }
    }
