    public class MyDbContext : DbContext
    {
    	private readonly IUserContext _userContext;
    
    	// For migrations
    	public MyDbContext() : base("DefaultConnectionString")
    	{
    		this.DisableFilter(EntityFilters.RestrictEntitiesToCurrentUser);
    		Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDbContext, Configuration>());
    	}
    
    	// For applications
    	public MyDbContext(IUserContext userContext) : base("DefaultConnectionString")
    	{
    		_userContext = userContext; 
    	}
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		// ... Code removed for brevity
    
    		base.OnModelCreating(modelBuilder);
    	}
    }
