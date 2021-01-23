    public class Context : DbContext
    {
        public Context()
        {
            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
            Database.Initialize(true);
        }
        public DbSet<ClinicianAvailability> ClinicianAvailabilitys { get; set; }
        public DbSet<SurgicalBooking> SurgicalBookings { get; set; }
        public DbSet<TheatreBooking> TheatreBookings { get; set; }
    }
