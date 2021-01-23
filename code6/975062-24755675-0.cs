    using System;
    namespace Demo
    {
    
        public class DbSet<T> { }
    
        public class Account { }
    
        public class PseudoContext
        {
            public DbSet<Account> Accounts {get; set;}
    
            public PseudoContext()
            {
                Accounts = new PseudoDbSet<Account>();
            }
        }
    
        public class PseudoDbSet<T> : DbSet<T> {}
    
        class Program
        {
    
            static void Main(string[] args)
            {
                
                PseudoContext ct = new PseudoContext();
                PseudoDbSet<Account> db = (PseudoDbSet<Account>)ct.Accounts;
    
                Console.WriteLine(typeof(PseudoDbSet<Account>).FullName);
                Console.WriteLine(ct.Accounts.GetType().FullName);
    
                Console.ReadLine();
    
            }
        }
    }
