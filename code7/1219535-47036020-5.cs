    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=MyOracleDbContext")
        { }
    	public static void Initialize()
    	{
    		DbConfiguration.SetConfiguration(new MyDbConfiguration());
    		Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Migrations.Configuration>());
    	}
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		modelBuilder.HasDefaultSchema(string.Empty);
    	}
    }
