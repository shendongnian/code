    public class FakeDbContext : DbContext
    {
        static FakeDbContext()
        {
            Database.SetInitializer<FakeDbContext>(null);
        }
        
        public virtual IDbSet<User> Users => new UserDbSet();
    }
