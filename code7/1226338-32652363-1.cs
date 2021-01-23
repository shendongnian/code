    CreateTable(
        "dbo.Codes",
        c => new
            {
                Id = c.String(nullable: false, maxLength: 128),
                Level = c.Byte(nullable: false),
            })
        .PrimaryKey(t => t.Id);
                
    CreateTable(
        "dbo.HelperCodes",
        c => new
            {
                HelperCodeId = c.String(nullable: false, maxLength: 128),
                Level = c.Byte(nullable: false),
                CommissioningFlag = c.Byte(nullable: false),
                LastChange = c.String(),
            })
        .PrimaryKey(t => t.HelperCodeId)
        .ForeignKey("dbo.Codes", t => t.HelperCodeId)
        .Index(t => t.HelperCodeId);
