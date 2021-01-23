    public partial class NameOfMyMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TableA", "DummyField", c => c.Boolean(nullable: false, defaultValue: true));
            DropColumn("dbo.TableA", "DummyField");
        }
    
        public override void Down()
        {
        }
    }
