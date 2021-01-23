    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
    
        protected override void OnConfiguring(DbContextOptions options)
        {
            options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Blogging;integrated security=True;");
        }
    }
