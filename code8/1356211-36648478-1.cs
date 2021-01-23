    public class YourContext: DbContext 
    {
        public SchoolDBContext(): base() 
        {
        }
    
        public DbSet<Material> Materials { get; set; }
        public DbSet<ScheduleRow> ScheduleRows { get; set; }
            
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("YourShema");
        }
    }
