    public class MyDBContext: DbContext
    {
        public MyDBContext() : base(AppSettings.DBConnectionString)
        {
        }
        public static MyDBContext Create()
        {
            return new MyDBContext();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Entries> Entries { get; set; }
    }
