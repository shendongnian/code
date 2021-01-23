    public class ConferenceContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Speaker> Speakers { get; set; } //since you are referencing the speaker class here
    }
