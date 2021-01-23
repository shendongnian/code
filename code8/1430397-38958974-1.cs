    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NavigationContext())
            {
                Console.Write("Enter address: ");
                var addr = Console.ReadLine();
                Console.Write("Enter person: ");
                var prs = Console.ReadLine();
                
                Address address = new Address { Name = addr };
                db.Addresses.Add(address);
                
                Person person = new Person { Name = prs, AddressID = address.AddressID };
                db.Persons.Add(person);
                db.SaveChanges();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            } 
        }
    }
    [Table("Person")]
    public class Person
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public int? AddressID { get; set; }
        //[ForeignKey("AddressID")]
        //public virtual Address Address { get; set; }
    }
    [Table("Address")]
    public class Address
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AddressID { get; set; }
        public string Name { get; set; }
        public int PersonID { get; set; }
        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }
    }
    public class NavigationContext : DbContext
    {
        public NavigationContext()
            : base("SQLDBConnection")
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
