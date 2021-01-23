    public class MyFinalOneTwoHandsContext :DbContext
    {
        public MyFinalOneTwoHandsContext()
            :base("Name=MyFinalOneTwoHandsContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new EventMap());
            modelBuilder.Configurations.Add(new UserEventMap());
        }
    }
