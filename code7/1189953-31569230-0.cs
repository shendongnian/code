    public class MockEFDbContext : EFDbContext
    {
        public MockEFDbContext()
        {
            Database.SetInitializer<EFDbContext>(null);
        }
    }
