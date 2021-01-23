    public class AppContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Compile error, the type int must be a reference type...
            //modelBuilder.Entity<Post>().HasRequired(p => p.BlogId).WithMany();
        }
    }
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BlogId { get; set; }
    }
