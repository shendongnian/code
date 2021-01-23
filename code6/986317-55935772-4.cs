    CreateTable(
        "dbo.Foos",
        c => new
            {
                Id = c.Guid(nullable: false),
                ...
            })
        .PrimaryKey(t => t.Id)
        ...;
