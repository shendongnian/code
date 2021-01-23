    public class TestContext : DbContext
        {
            public TestContext()
                : base("name=MyConnectionString")
            {
    
            }
