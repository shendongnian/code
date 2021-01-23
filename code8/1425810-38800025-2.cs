        public class AppContext : DbContext
    {
       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
          // quick and dirty solution
          // modelBuilder.Entity<YourModelEntity>.Property(p => p.Birth).IsOptional()
          // cleaner solution
          modelBuilder.Configurations.Add(new YourModelTypeConfiguration());
       }
       
    }
