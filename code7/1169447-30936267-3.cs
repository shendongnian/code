     public class MyDbContext: DbContext, IDisposable where T : class
    {
        public DbSet<User> Users { get; set; }        
        public MyDbContext() : base("$DbConnectionString") { }         
        public new void Dispose()
        {
            base.Dispose();            
        }      
    } 
