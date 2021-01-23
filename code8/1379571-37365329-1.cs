    public sealed class Derived : Base
    {
        public string Name { get; set; }
    
        public class DerivedConfiguration : EntityTypeConfiguration<Derived>
        {
            public DerivedConfiguration()
            {
                Property(p => p.RowVersion);
            }
        }
    
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder
            .Configurations.Add(new Derived.DerivedConfiguration());
    }
