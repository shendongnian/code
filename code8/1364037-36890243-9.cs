    var links = new List<Link> {
        new Link { FKName = "FK_Factory_Person", SchemaName = "dbo", Table = "Factory", Column = "PersonId", RefTable = "Person", RefColumn = "Id" },
        new Link { FKName = "FK_Car_Person", SchemaName = "dbo", Table = "Car", Column = "PersonId", RefTable = "Person", RefColumn = "Id" },
        new Link { FKName = "FK_Factory_Car", SchemaName = "dbo", Table = "Factory", Column = "CarId", RefTable = "Car", RefColumn = "Id" },
        new Link { FKName = "FK_TEST", SchemaName = "dbo", Table = "Person", Column = "TestId", RefTable = "Test", RefColumn = "Id" }
    };
    
    var answer = ProcessItems(links);  
