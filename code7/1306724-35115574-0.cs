    public class FooConfiguration : EntityTypeConfiguration<Foo>
    {
        public FooConfiguration()
        {
            ToTable("ViewName");
            HasKey(p => p.Id); // You also have to configure a key
        }
    }
