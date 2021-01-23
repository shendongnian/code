    public partial class ApplicationDbContext : DbContext
    {	
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Application");
            // Fluent API configuration
        }	
    }
	
    public partial class CompanyDBContext : DbContext
    {	
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Company");
            // Fluent API configuration
        }	
    }	
