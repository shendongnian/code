    public class MainDbContext: IdentityDbContext<User>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
    
        public MainDbContext()
            :base("MainDb")
        {
    
        }
    }
