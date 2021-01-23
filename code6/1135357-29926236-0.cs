    [DbConfigurationType(typeof(DatabaseConfiguration))] 
    public class MyContext : DbContext
    {
        public MyContext() : base("MyDB") 
        {
        }
    
        public DbSet<MyObject> MyObject { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
