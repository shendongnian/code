    CreateTable(
        "dbo.B",
        c => new
            {
                Id = c.Int(nullable: false, identity: true),
                BId = c.Int(),
            })
        .PrimaryKey(t => t.Id)
        .ForeignKey("dbo.A", t => t.BId)
        .Index(t => t.BId);
                
    CreateTable(
        "dbo.A",
        c => new
            {
                Id = c.Int(nullable: false, identity: true),
                AId = c.Int(),
            })
        .PrimaryKey(t => t.Id)
        .ForeignKey("dbo.B", t => t.AId)
        .Index(t => t.AId);
           
