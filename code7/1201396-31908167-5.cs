     public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
     {        
        public SharedDocumentModel()
            : base("MyContext")
        {
    
        }        
    
        public virtual DbSet<SharedDocument> PortalDocuments { get; set; }
     }
