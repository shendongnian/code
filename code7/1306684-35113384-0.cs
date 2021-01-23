    // HumanConfiguration.cs
    public class HumanConfiguration : EntityTypeConfiguration<Human>
    {
        public HumanConfiguration()
        {
            this.ToTable("Human");
        }
    }
    
    // YourDbContext.cs
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.Add(new HumanConfiguration());
        base.OnModelCreating(modelBuilder);
    }
