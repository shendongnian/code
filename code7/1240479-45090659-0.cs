    public class 201707132034165_MyAwesomeDbInitial : DbMigration
    {
    	#region <Methods>
    
    	public override void Up()
    	{
    		CreateTable(
    			"dbo.HasOverdrive",
    			c => new
    			{
    				HasOverdriveId = c.Int(nullable: false, identity: true),
    				HasOverdriveValue = c.String(nullable: false, maxLength: 5)
    			})
    			.PrimaryKey(t => t.HasOverdriveId)
    			.Index(t => t.HasOverdriveValue, unique: true, name: "UX_HasOverdrive_AlternateKey");
    	}
       
    	// This should is called by your DbConfiguration class
    	public void Seed(MyAwesomeDbContext context)
    	{
    		// DO THIS FIRST !!!!!!!!!!!!!!!
    		context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('HasOverdrive', RESEED, 0)");
    
    		// LOOKUPS
    		SeedHasOverdrive(context);
    	}
    	
    	private void SeedHasOverdrive(MeasurementContractsDbContext context)
    	{
    		context.HasOverdrive.AddOrUpdate
    		(
    			m => m.Id,
    			new HasOverdrive { HasOverdriveId = 0, HasOverdriveValue = "No" }, // 0 = FALSE 
    			new HasOverdrive { HasOverdriveId = 1, HasOverdriveValue = "Yes" } // 1 = TRUE
    		);
    	}
    	#endregion
    }
