    public class TestContext : DbContext
    {
        public TestContext(DbConnection connection) : base(connection, true) { }
        public DbSet<InternCode> InternCodes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Version> Versions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VersionMap());
        }
    }
    public class InternCode : DataCode
    {
        public string PrimaryRelationalOperator { get; set; }
        public string PrimaryValue { get; set; }
        public string SecondaryRelationalOperator { get; set; }
        public string SecondaryValue { get; set; }
        public virtual ICollection<Version> Versions { get; set; }
    }
    public class Model : DataCode
    {
        public ICollection<string> Aliases { get; set; }
        public bool ExportOnly { get; set; }
        public virtual ICollection<Version> Versions { get; set; }
        public void GetOptions()
        {
            throw new NotImplementedException();
        }
    }
    public class VersionMap : EntityTypeConfiguration<Version>
    {
        public VersionMap()
        {
            // Relationships
            HasMany(t => t.Models)
                .WithMany(t => t.Versions);
            HasMany(t => t.DataReleaseLevels)
                .WithMany(t => t.Versions);
        }
    }
