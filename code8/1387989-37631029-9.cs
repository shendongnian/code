    public interface IDbContext {
        IDbSet<Blog> Blogs { get; set; }
        //...other properties and members needed for db context
        int SaveChanges();
    }
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
    
        }
        public IDbSet<Blog> Blogs { get; set; }
    }
