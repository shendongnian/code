    [ExcludeFromCodeCoverage]
    public partial class AddVersionAndChangeActivity : DbMigration
    {
    	public override void Up()
    	{
    		this.AddColumnIfNotExists("dbo.Action", "VersionId", c => c.Guid(nullable: false));
    		AlterColumn("dbo.Action", "Activity", c => c.String(nullable: false, maxLength: 8000, unicode: false));
    	}
    	
    	public override void Down()
    	{
    		AlterColumn("dbo.Action", "Activity", c => c.String(nullable: false, maxLength: 50));
    		DropColumn("dbo.Action", "VersionId");
    	}
    }
