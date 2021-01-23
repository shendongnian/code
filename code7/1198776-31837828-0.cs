    class MyContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Index(b => b.Url)
                .Unique();
        }
    }
