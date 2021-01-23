    public partial class NameOfMyMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Site", "DummyField", c => c.Boolean(nullable: false, defaultValue: true));
            DropColumn("dbo.Site", "DummyField");
        }
    
        public override void Down()
        {
        }
    }
