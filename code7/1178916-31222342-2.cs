    public class EmploymentDbContext : DbContext
    {
        // constructor, which will also call DbContext's (base) constructor
        public EmploymentDbContext() : base("name=EmploymentDbContext") { } 
    
        public DbSet<EmploymentHistory> EmploymentsHistory { get; set; }
    }
