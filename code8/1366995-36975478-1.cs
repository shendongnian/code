    public class MyContext : DbContext
    {
        static readonly string ConnectionString;
        static MyContext()
        {
            IConfiguration configuration = new Configuration().AddJsonFile("config.json");
            ConnectionString = configuration["Data:DefaultConnection:ConnectionString"]);
        }
        public MyContext()
            : base(ConnectionString);
        {
        }
    }
