     public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class SharedDocumentModel : IdentityDbContext<ApplicationUser>
    {
        public SharedDocumentModel()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public virtual DbSet<SharedDocument> PortalDocuments { get; set; }
        public static SharedDocumentModel Create()
        {
            return new SharedDocumentModel();
        }
    }
