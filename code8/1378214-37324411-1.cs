    public class Client {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime Birthday { get; set; }
        public string Type { get; set; }
        ...
    }
    
    public class Account {
        public int Id { get; set; }
        public Client Client { get; set; }
        public string Type { get; set; }
        public DateTime RunTime { get; set; }
        public DateTime Opened { get; set; }
        public string Description { get; set; }
        ...
    }
    
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {
        }
    
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
