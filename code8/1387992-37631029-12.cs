    public interface IDbContext {
        DbSet<Blog> Blogs { get; set; }
        //...other properties and members needed for db context
        int SaveChanges();
    }
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
    
        }
        public DbSet<Blog> Blogs { get; set; }
    }
