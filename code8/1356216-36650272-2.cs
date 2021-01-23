    public class YourContext: DbContext 
    {
        public SchoolDBContext(): base() 
        {
        }
    
        public DbSet<Material> Materials { get; set; }
        public DbSet<ScheduleRow> ScheduleRows { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Fluent API
            modelBuilder.Entity<Material>()
                .HasMany(e => e.ScheduleRow)
                .WithRequired(e => e.Material)
                .HasForeignKey(e => e.Id)
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
