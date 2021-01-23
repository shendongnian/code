    public class PackageVersion
    {
        public int Id { get; set; }
    
        [Required]
        [MaxLength(128)]
        public string PackageName { get; set; }        
        public virtual Status Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
    
    public class DeploymentLog
    {
        public int Id { get; set; }
        public virtual PackageVersion PackageVersion { get; set; }        
        public virtual Status Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
        
    public class Status
    {
        public int Id { get; set; }
    
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
    }
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Status> Status { get; set; }
        public DbSet<PackageVersion> PackageVersions { get; set; }
        public DbSet<DeploymentLog> DeploymentLogs { get; set; }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
