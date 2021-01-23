    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SharedDocument>()
                .HasRequired(e => e.CreatedBy)
                .WithMany()
                .Map(e => e.MapKey("CreatedByID"));
            modelBuilder.Entity<SharedDocument>()
                .HasRequired(e => e.ModifiedBy)
                .WithMany()
                .Map(e => e.MapKey("ModifiedByID"));
        }
        // rest of code same as before
    }
