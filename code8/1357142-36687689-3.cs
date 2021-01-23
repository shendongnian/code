    public interface IDbContextFactory
    {
        IdentityDbContext<User> GetContext();
    }
    
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IdentityDbContext<User> _context;
    
        public DbContextFactory()
        {
            _context = new RequestContext("ConnectionStringName");
        }
    
        public IdentityDbContext<User> GetContext()
        {
            return _context;
        }
    }
