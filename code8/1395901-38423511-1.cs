    public class BloggingContext : DbContext, IBloggingContext {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options) { }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
