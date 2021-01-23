    public class MyContext : DbContext
    {
        public MyContext(string connectionString)
            : base(connectionString);
        {
        }
    }
    public static class ContextFactory
    {
        static readonly IConfiguration Configuration;
        static ContextFactory()
        {
            Configuration = new Configuration().AddJsonFile("config.json");
        }
        public static MyContext CreateMyContext()
        {
            return new MyContext(Configuration["Data:DefaultConnection:ConnectionString"]);
        }
    }
