    public class ProfessionalContext : DbContext
    {
        public ProfessionalContext(string connectionString)
            : base(connectionString)
        {
            //This line is optional but it prevents initialising the database
            //every time you connect to a new database
            Database.SetInitializer<ProfessionalContext>(null);
        }
        public DbSet<Professional> Professionals { get; set; }
    }
