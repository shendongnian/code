    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<ApplicationUser>(b =>
            {
                // you could limit the field size to just long enough for a guid id as string
                b.Property(p => p.Id)
                    .HasMaxLength(36);
                // instead, you could define the id as Guid but more work required
                //b.Property(p => p.Id)
                //   .ForSqlServerHasColumnType("uniqueidentifier")
                //   .ForSqlServerHasDefaultValueSql("newid()")
                //   .IsRequired();
            });
        }
    }
