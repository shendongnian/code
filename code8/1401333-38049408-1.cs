    public class DatabaseContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Machine>()
                .HasOptional(_ => _.MachineTypeApproval)
                .WithMany();
        }
    }
