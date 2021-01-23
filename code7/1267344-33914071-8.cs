    public class SampleDbContext: DbContext
    {
        public SampleDbContext()
            : base("name=CascadeOnDelete")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasOptional(v => v.Person)
                .WithMany()
                .HasForeignKey(v => v.PersonId);
                //.WillCascadeOnDelete();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Person> Persons {get;set;}
        public DbSet<Vehicle> Vehicles {get;set;}
    }
    public class Person
    {
        public int PersonId {get;set;}
        public string Name {get;set;}
    }
    public class Vehicle
    {
        public int VehicleId {get;set;}
        public string Model { get; set; }
        public int? PersonId { get; set; }
        public virtual Person Person {get;set;}
    } 
