    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("MyConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, MyObjextContextMigration>());
        }
        ...
