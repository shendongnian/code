    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ConnectionStringName")
        {
            Database.SetInitializer<ApplicationDbContext>(null);
        }
    }
