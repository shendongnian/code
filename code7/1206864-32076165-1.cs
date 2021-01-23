    public class Context : DbContext
    {
        public Context() : base("Model2")
        {
            
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectET> ProjectETs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasKey(i => i.ProjectId);
            modelBuilder.Entity<ProjectTask>()
                .HasKey(i => i.ProjectTaskId);
            
            base.OnModelCreating(modelBuilder);
        }
        
    }
