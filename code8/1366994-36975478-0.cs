    public class MyContext : DbContext
    {
        public MyContext()
            : base(new Configuration().AddJsonFile("config.json")["Data:DefaultConnection:ConnectionString"]);
        {
        }
    {
