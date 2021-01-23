    public class TestContext : DbContext
        {
            public TestContext()
                : base(new SqlCeConnection(GetConnectionString()),true)
            {
    
            }
