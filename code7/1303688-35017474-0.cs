    public class ConferenceContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Session> Speakers { get; set; }
    }
