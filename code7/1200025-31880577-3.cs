    public class DataContext : DbContext, IDataContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<STCIProductInteractiveInfo>()
                .HasRequired(e => e.ModifyUser)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
