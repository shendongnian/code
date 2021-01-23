    public override void Up()
    {
        AddColumn("dbo.RequestValidationErrors", "IsBreaking", c => c.Boolean(nullable: false, default: true));
        Sql("UPDATE dbo.RequestValidationErrors SET IsBreaking = 0 WHERE WordCode = \"RequestValidationError.MoreThanOneItemFound\"");
    }
