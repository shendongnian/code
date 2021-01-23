    public class DBContext : IdentityDbContext<ApplicationUser>
    {
    public DBContext()
       : base("DefaultConnection", throwIfV1Schema: false)
    {
    }
    //public DbSet<person> Persons { get; set; }
    public DbQuery<person> Persons
    {
        get
        {
            // Don't track changes to query results
            return Set<person>().AsNoTracking();
        }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        modelBuilder.Entity<person>();
    }
    public static DBContext Create()
    {
        return new DBContext();
    }
