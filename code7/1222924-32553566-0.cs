        public class MyDbContext : DbContext
        {
            DbSet<User> Users { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>()
                    .HasRequired<User>(x => x.CreatedBy)
                    .WithMany();
    
                modelBuilder.Entity<User>()
                    .HasRequired<User>(x => x.ModifiedBy)
                    .WithMany();
            }
        }
