    CreateTable(
        "dbo.Items",
        c => new
            {
                ItemId = c.Int(nullable: false, identity: true),
            })
        .PrimaryKey(t => t.ItemId);
                
    CreateTable(
        "dbo.ItemsAssociation",
        c => new
            {
                AssociatedItemId = c.Int(nullable: false),
                ItemId = c.Int(nullable: false),
            })
        .PrimaryKey(t => new { t.AssociatedItemId, t.ItemId })
        .ForeignKey("dbo.Items", t => t.AssociatedItemId)
        .ForeignKey("dbo.Items", t => t.ItemId)
        .Index(t => t.AssociatedItemId)
        .Index(t => t.ItemId);
