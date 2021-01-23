    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       protected override void OnModelCreating(ModelBuilder builder)
       {
          base.OnModelCreating(builder);
          builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
       }
    }
