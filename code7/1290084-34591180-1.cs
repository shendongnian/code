    public class TestDbContext: DbContext
        {
            public DbSet<SizeCount> SizeCounts { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Size> Sizes { get; set; }
            public DbSet<Color> Colors { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
               base.OnModelCreating(modelBuilder);
            }
        }
