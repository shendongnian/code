     public class SharedDocumentModel : IdentityDbContext<ApplicationUser, Role,
        int, UserLogin, UserRole, UserClaim>
     {        
        public SharedDocumentModel()
            : base("MyContext")
        {
    
        }        
    
        public virtual DbSet<SharedDocument> PortalDocuments { get; set; }
     }
