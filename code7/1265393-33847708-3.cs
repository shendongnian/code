    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class FooTypeConfiguration : EntityTypeConfiguration<Foo>
    {
        public FooTypeConfiguration()
        {
            ToTable("Foos");
            HasKey(t => t.Id);
            Property(t => t.Name).HasMaxLength(200)
                                 .IsRequired();
        }
    }
