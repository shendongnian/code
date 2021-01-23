    public class Person
    {
        // properties
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Address Address { get; set; }
    }
    public class Address
    {
        // properties
        public int Id { get; set; }
        public string Location { get; set; }
        public virtual Person Person { get; set; }
    }
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            ToTable("Person");
            HasKey(p => p.Id);
        }
    }
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            ToTable("Address");
            HasKey(p => p.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            
            HasRequired(p => p.Person)
                .WithOptional(a => a.Address);
        }
    }
    public class AppObjectContext : DbContext
    {
        public AppObjectContext() : base("AppConnectionString")
        {
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new AddressMap());
        }
    }
