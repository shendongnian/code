    public class DatabaseContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Machine>()
                .HasRequired(_ => _.MachineTypeApproval)
                .WithMany();
        }
    }
