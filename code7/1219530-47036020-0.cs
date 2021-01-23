    public class HistoryDbContext : HistoryContext
    {
    	internal static readonly string SCHEMA;
    
    	static HistoryDbContext()
    	{
    		SCHEMA = ConfigurationManager.AppSettings["Schema"];
    	}
    
    	public HistoryDbContext(DbConnection dbConnection, string defaultSchema)
    			: base(dbConnection, defaultSchema)
    	{ }
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		base.OnModelCreating(modelBuilder);
    		modelBuilder.HasDefaultSchema(SCHEMA);
    	}
    }
