    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("PacificPetEntities", throwIfV1Schema: false)
        {
        }
        public DbSet<Expense> Expenses { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
    }
