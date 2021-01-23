    public class Person
        {
            [Key]
            public int Id{get;set;}
            [Required]
            public string name { get; set; }
            [Required]
            public string surname { get; set; }
        }
    public class personContext : DbContext
        {
            public personContext()
                : base("EmploymentDbContext")
            {
                //If model change, It will re-create new database.
                Database.SetInitializer<personContext>(new DropCreateDatabaseIfModelChanges<personContext>());
            }
            public DbSet<Person> person { get; set; }
       }
