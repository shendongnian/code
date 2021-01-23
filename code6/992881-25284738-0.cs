        [Table("CustomerTest")]
        public class Customer
        {
            [Key]
            public int Id { get; set; }
            public string FirstName { get; set; }
            public int Status { get; set; }
        }
 
        public class CustomerContext : DbContext
        {
            public CustomerContext(): base("name=Program.CustomerContext"){}
            public DbSet<Customer> Customers { get; set; }
        }
        //PM> Install-Package EntityFramework
        //PM> Install-Package EntityFramework.SqlServerCompact
        static void Main(string[] args)
        {
            using (var db = new CustomerContext())
            {
                var item = new Customer {FirstName = "test", Status = 2};
                db.Customers.Add(item);
                db.SaveChanges();
 
                var items = db.Customers.Where(o => (o.FirstName == "test" && o.Status > 1));
                Console.WriteLine(items.ToString());
            }
            Console.ReadKey();
        }
