    namespace TestApp
    {
        public class Account
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        public class MyClassDataContext : DbContext
        {
            public DbSet<Account> Accounts { get; set; }
        }
        class Program
        {    
            static void Main(string[] args)
            {
                using (var x = new MyClassDataContext())
                {
                    x.Accounts.Add(new Account { Name = "Drew" });
                    x.SaveChanges();
    
                    var y = x.Accounts;
                    foreach (var s in y)
                    {
                        Console.WriteLine(s.Name);
                    }
                }
    
                Console.ReadKey();
            }
        }
    }
