    public class Context : DbContext
    {
        public DbSet<Group> Groups { get; set; }
    }
    
    public class Group
    {
        public List<User> Members { get; set; }
        public List<Article> Articles { get; set; }
        public List<Customer> Customers { get; set; }
    }
