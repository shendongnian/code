    static void CreateAndSeedDatabase()
    {
        Context context = new Context();
        TimeTracker entry1 = new TimeTracker() { UserId = 1, LoginTime = new DateTime(2000, 1, 1, 0, 0, 0), LogoutTime = new DateTime(2000, 1, 1, 1, 0, 0) };
        TimeTracker entry2 = new TimeTracker() { UserId = 1, LoginTime = new DateTime(2000, 1, 1, 1, 0, 0), LogoutTime = new DateTime(2000, 1, 1, 2, 0, 0) };
        
        TimeTracker entry3 = new TimeTracker() { UserId = 1, LoginTime = new DateTime(2000, 1, 2, 0, 0, 0), LogoutTime = new DateTime(2000, 1, 2, 2, 0, 0) };
        TimeTracker entry4 = new TimeTracker() { UserId = 2, LoginTime = new DateTime(2000, 1, 1, 0, 0, 0), LogoutTime = new DateTime(2000, 1, 1, 1, 0, 0) };
        List<TimeTracker> entryList = new List<TimeTracker>() { entry1, entry2, entry3, entry4 };
        context.TimeTrackers.AddRange(entryList);
        context.SaveChanges();
    }
    class Context : DbContext
    {
        public Context()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
            Database.Initialize(true);
        }
        public DbSet<TimeTracker> TimeTrackers { get; set; } 
    }
    public class TimeTracker
    {
        public int TimeTrackerId { get; set; }
        public int UserId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
    }
