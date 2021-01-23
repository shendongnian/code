    public override void Up()
    {
        CreateTable(
            "dbo.Matrix_Element",
            c => new
                {
                    RowID = c.Int(nullable: false),
                    ColID = c.Int(nullable: false),
                    cellValue = c.Int(),
                    R = c.String(),
                })
            .PrimaryKey(t => new { t.RowID, t.ColID });//Success!
                
    }
