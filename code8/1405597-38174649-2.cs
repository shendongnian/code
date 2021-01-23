    public  class TestContext2 : DbContext
    {
    	public TestContext2() : base(My.Config.ConnectionStrings.TestDatabase)
    	{
    		
    	}
    	public DbSet<License> Licenses { get; set; }
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		modelBuilder.Entity<License>()
    			.HasOptional(v => v.UpgradeTo)
    			.WithOptionalDependent(x => x.InternalUpgradedFrom);
    
    		modelBuilder.Entity<License>()
    			.HasOptional(v => v.UpgradedFrom)
    			.WithOptionalDependent(x => x.InternalUpgradedTo);
    	}
    }
