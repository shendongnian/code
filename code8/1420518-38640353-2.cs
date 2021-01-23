    public class FlightsDatabase :DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<ArchiveFlight> FlightsArchive { get; set; }
        public DbSet<Passanger> Passengers { get; set; }
    }
