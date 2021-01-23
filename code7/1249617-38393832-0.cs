    public class YourContext: DbContext 
    {
        public YourContext(): base() 
        {
        }
    
        public DbSet<Log> Logs { get; set; }
            
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("SHEMA_NAME");
        }
    }
