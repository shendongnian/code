    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("DbContext")
        {
        }
        public DbSet<BandyProfile> BandyProfiles { get; set; }
        public DbSet<YogaClass> YogaClasses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YogaClass>()
                .HasKey(yogaClass => new {yogaClass.YogaClassId, yogaClass.BandyProfileRefId});
            base.OnModelCreating(modelBuilder);
        }
    }
