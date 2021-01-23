    public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsEnabled", c => c.Boolean(nullable: false, defaultValue: true));
        }
  
