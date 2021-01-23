    public partial class AddSizeToWidget : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Widgets", "Size", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Widgets", "Size");
        }
    }
