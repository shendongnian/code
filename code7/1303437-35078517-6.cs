    public class MyDbContext : DbContext
    {
        public DbSet<MyLegacyUser> MyLegacyUser { get; set; }
        // For simplicity I will add only the OnModelCreating method here
        protected override void OnModelCreating
        {
            modelBuilder.Entity<MyLegacyUser>(entity =>
            {
                entity.Ignore(e => e.AccessFailedCount);
                entity.Ignore(e => e.Claims);
                entity.Ignore(e => e.ConcurrencyStamp);
                entity.Ignore(e => e.Email);
                entity.Ignore(e => e.EmailConfirmed);
                entity.Ignore(e => e.Id);
                entity.Ignore(e => e.LockoutEnabled);
                entity.Ignore(e => e.LockoutEnd);
                entity.Ignore(e => e.Logins);
                entity.Ignore(e => e.NormalizedEmail);
                entity.Ignore(e => e.NormalizedUserName);
                entity.Ignore(e => e.PasswordHash);
                entity.Ignore(e => e.PhoneNumber);
                entity.Ignore(e => e.PhoneNumberConfirmed);
                entity.Ignore(e => e.Roles);
                entity.Ignore(e => e.SecurityStamp);
                entity.Ignore(e => e.TwoFactorEnabled);
            }
        }
    }
