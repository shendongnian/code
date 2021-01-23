    public class MyDbContext : DbContext
    {
        public MyDbContext(string connString) : base(connString)
        {
        }
    }
