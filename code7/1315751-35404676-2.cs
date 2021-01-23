    public class ApplicationUser : IdentityUser
    {
        // Write any customer properties that you want here
        // as an example I am adding a property Name
        public string Name { get; set; }
    }
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        { }
    
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
