    public partial class AddColorToWidget : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Widgets", "Size", c => c.Int());
            AddColumn("dbo.Widgets", "Color", c => c.Int());
        }
        ...
    }
