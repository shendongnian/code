    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        private DbSet<Article> Articles { get; set; }
        public ApplicationDbContext()
        : base("DefaultConnection")
        {
        }
    
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
