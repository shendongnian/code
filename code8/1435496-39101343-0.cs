    public class ProfessionalContext : DbContext
    {
        public ProfessionalContext(string connectionString)
            : base(connectionString)
        {
        }
        public DbSet<Professional> Professionals { get; set; }
    }
