        public class IdentityDataContext : IdentityDbContext<User>
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("AspNetUsers").Ignore(u => u.Area);
            modelBuilder.Entity<AdminUser>().ToTable("AdminUsers");
        }
    }
