    public class DomainDbContext : DbContext
    {      
        /*skipping other stuff you have here*/ 
        public DbSet<Point> Points { get; set; }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Fill Properties with private fields 
            builder.Entity<Point>().Property(m => m.X).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Entity<Point>().Property(m => m.Y).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Entity<Point>().Property(m => m.Z).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
