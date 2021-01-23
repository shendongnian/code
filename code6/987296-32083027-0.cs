    public class MyDbContext : IdentityDbContext<ApplicationUser>, IMyDbContext
    {
        public IDbSet<MyOtherEntity> OtherEntities { get; set; }
        public MyDbContext() : base("MyDb", false)
        {
            Database.SetInitializer<MyDbContext>(null);
        }
        public static DbContext Create()
        {
            return new MyDbContext();
        }
    }
