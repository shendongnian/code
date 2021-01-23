    public class MyContext : IdentityDbContext
    {
        public MyContext()
            : base(<connection string name>)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users");
            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogins");
        }
    }
