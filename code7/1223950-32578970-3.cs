    public class AClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class AClassConfiguration : EntityTypeConfiguration<AClass>
    {
        public AClassConfiguration()
        {
            this.ToTable("table_name");
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("name");
        }
    }
