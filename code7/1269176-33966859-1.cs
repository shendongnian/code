    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("YourEFConnStringName")
        {
            Database.SetInitializer<MyDbContext>(new MyNiceInitializer());
        }
        public DbSet<Category> Categories { set; get; }
        //Other Items goes here...
    }
