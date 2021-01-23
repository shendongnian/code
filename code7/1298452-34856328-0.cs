    public class BlogConfig
    {
        public BlogConfig(EntityTypeBuilder<Blog> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            // etc..
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new BlogConfig(modelBuilder.Entity<Blog>());
    }
