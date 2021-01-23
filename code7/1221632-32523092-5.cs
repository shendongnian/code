    CreateTable(
        "dbo.Teams",
        c => new
            {
                CatId = c.Int(nullable: false),
                DogId = c.Int(nullable: false),
                PigId = c.Guid(nullable: false),
            })
        .PrimaryKey(t => new { t.CatId, t.DogId, t.PigId })
        .ForeignKey("dbo.Cats", t => t.CatId, cascadeDelete: true)
        .ForeignKey("dbo.Dogs", t => t.DogId, cascadeDelete: true)
        .ForeignKey("dbo.Pigs", t => t.PigId, cascadeDelete: true)
        .Index(t => t.CatId)
        .Index(t => t.DogId)
        .Index(t => t.PigId);
                
    CreateTable(
        "dbo.Cats",
        c => new
            {
                Id = c.Int(nullable: false, identity: true),
            })
        .PrimaryKey(t => t.Id);
                
    CreateTable(
        "dbo.Dogs",
        c => new
            {
                Id = c.Int(nullable: false, identity: true),
            })
        .PrimaryKey(t => t.Id);
                
    CreateTable(
        "dbo.Pigs",
        c => new
            {
                PigId = c.Guid(nullable: false),
            })
        .PrimaryKey(t => t.PigId);
