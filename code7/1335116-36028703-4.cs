    public partial class ChangeDownloadTokenIdToGuid : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DownloadTokens");
    
            DropColumn("dbo.DownloadTokens", "Id");
            AddColumn("dbo.DownloadTokens", "Id", c => c.Guid(nullable: false, identity: true));
    
            AddPrimaryKey("dbo.DownloadTokens", "Id");
        }
    
        public override void Down()
        {
            DropPrimaryKey("dbo.DownloadTokens");
    
            DropColumn("dbo.DownloadTokens", "Id");
            AddColumn("dbo.DownloadTokens", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DownloadTokens", "Id");
        }
    }
