    public class FakeDbContext : DbContext
    {
        static FakeDbContext()
        {
            Database.SetInitializer<FakeDbContext>(null);
        }
        
        public FakeDbContext() : base("TestConnectionString") { }
        
        public virtual IDbSet<User> Users => new UserDbSet();
    }
