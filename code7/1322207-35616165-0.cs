    public class SolutionContext: IdentityDbContext<User>
    {
        public DbSet<LanguageTest> LanguageTests { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public SolutionContext()
            : base("SolutionContext", throwIfV1Schema: false)
        {
        }
        public static SolutionContext Create()
        {
            return new SolutionContext();
        }
    }
