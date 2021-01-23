    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    
            public DbSet<Book> Books { get; set; }
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }
    
            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
    }
