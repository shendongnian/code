    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }
            //ADD JUST THIS LINE
            public DbSet<Person> People { get; set; }
            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }
