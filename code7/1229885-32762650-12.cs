    CreateTable(
        "dbo.Shipments",
        c => new
            {
                ShipmentId = c.Int(nullable: false, identity: true),
            })
        .PrimaryKey(t => t.ShipmentId);
                
    CreateTable(
        "dbo.ShipmentNumbers",
        c => new
            {
                ShipmentNumberId = c.Int(nullable: false, identity: true),
                ShipmentId = c.Int(nullable: false),
            })
        .PrimaryKey(t => t.ShipmentNumberId)
        .ForeignKey("dbo.Shipments", t => t.ShipmentId)
        .Index(t => t.ShipmentId);
