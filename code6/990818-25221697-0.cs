    public class AppContext : DbContext
    {
        public DbSet<DocumentSet> DocumentSets { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DocumentSetTypeConfiguration());
            modelBuilder.Configurations.Add(new DocumentIdentifierTypeConfiguration());
        }
    }
    public class DocumentSetTypeConfiguration : EntityTypeConfiguration<DocumentSet>
    {
        public DocumentSetTypeConfiguration()
        {
            HasKey(f => f.Id);
            Property(f => f.Id).HasColumnName("setId");
            HasMany(f => f.DocumentIdentifiers).WithRequired().HasForeignKey(x => x.SetId);
        }
    }
    public class DocumentIdentifierTypeConfiguration : EntityTypeConfiguration<DocumentIdentifier>
    {
        public DocumentIdentifierTypeConfiguration()
        {
            ToTable("DocIdentifier");
            HasKey(f => f.Id);
            Property(f => f.Id).HasColumnName("docIdId");
            Property(f => f.SetId).HasColumnName("docSetId");
        }
    }
    public class DocumentSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DocumentIdentifier> DocumentIdentifiers { get; set; }
    }
    public class DocumentIdentifier
    {
        public int Id { get; set; }
        public int SetId { get; set; }
        public string CustomId { get; set; }
    }
