    public class FakeDbContext : DbContext
    {
        static FakeDbContext()
        {
            Database.SetInitializer<FakeDbContext>(null);
        }
        
        public FakeDbContext() { }
        
        public virtual IDbSet<User> Users => new UserDbSet();
    }
