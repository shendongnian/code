    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("MyConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new MigrateDatabaseToLatestVersion<ApplicationDbContext, MyObjextContextMigration>());
        }
        ...
