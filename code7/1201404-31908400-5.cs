    // This class already added to your project
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        // This context already had ApplicationUser set you don't need to add it again
        // add your own new entities 
        public DbSet<SharedDocument> PortalDocuments { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
