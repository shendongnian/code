    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       protected override void OnModelCreating(ModelBuilder builder)
       {
          base.OnModelCreating(builder);
          builder.Entity&lt;ApplicationUser>().ToTable("Users");
          builder.Entity&lt;IdentityRole>().ToTable("Roles");
          builder.Entity&lt;IdentityUserRole&lt;string>>().ToTable("UserRoles");
          builder.Entity&lt;IdentityUserClaim&lt;string>>().ToTable("UserClaims");
          builder.Entity&lt;IdentityUserLogin&lt;string>>().ToTable("UserLogins");
          builder.Entity&lt;IdentityRoleClaim&lt;string>>().ToTable("RoleClaims");
          builder.Entity&lt;IdentityUserToken&lt;string>>().ToTable("UserTokens");
       }
    }
