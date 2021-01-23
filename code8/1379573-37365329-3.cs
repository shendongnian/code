    public abstract class Base
    {
        public Guid Id { get; set; }
        private byte[] RowVersion { get; set; }
    
        public class BaseConfiguration : EntityTypeConfiguration<Base>
        {
            public BaseConfiguration()
            {
                Property(p => p.RowVersion);
            }
        }
    
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder
            .Configurations.Add(new Base.BaseConfiguration());
    }
