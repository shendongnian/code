    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       protected override void OnModelCreating(ModelBuilder builder)
       {
          base.OnModelCreating(builder);
          builder.Entity<ApplicationUser>().ToTable("Users");
          builder.Entity<IdentityRole>().ToTable("Roles");
          builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
          builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
          builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
          builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
          builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
       }
    }
