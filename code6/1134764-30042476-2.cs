     public partial class AW : DbContext
    {
        public AW()
            : base("name=AWConnectionString")
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
        
        public virtual DbSet<Person> People { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Person>().ToTable("Person.Person");
            modelBuilder.Entity<Employee>().ToTable("HumanResources.Employee");
        }
    }
