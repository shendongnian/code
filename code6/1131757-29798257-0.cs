    public override void Up()
    {
        AlterColumn("dbo.MyTable", "Date", c => c.DateTime(nullable: true,
                                                           defaultValue: "NULL"));
        AlterColumn("dbo.MyTable", "Date", c => c.DateTime(nullable: false));
    }
