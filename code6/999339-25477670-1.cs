    public class AwesomeEntity
    {
        public int Id { get; set; }
    }
    public class AwesomeDbContext : DbContext
    {
        static AwesomeDbContext()
        {
            Database.SetInitializer(new AwesomeDatabaseInitializer());
        }
        public IDbSet<AwesomeEntity> Entities { get; set; }
    }
    public class AwesomeDatabaseInitializer : MigrateDatabaseToLatestVersion<AwesomeDbContext, AwesomeMigrationsConfiguration>
    {
        public override void InitializeDatabase(AwesomeDbContext context)
        {
            // TODO: Run code before migration here...
            base.InitializeDatabase(context);
        }
    }
    public class AwesomeMigrationsConfiguration : DbMigrationsConfiguration<AwesomeDbContext>
    {
        public AwesomeMigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(AwesomeDbContext context)
        {
            // TODO: Seed database here...
        }
    }
