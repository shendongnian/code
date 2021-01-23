        var items = new MongoClient(connectionString).GetDatabase(database).GetCollection<YOUR_CLASS>("items"); 
        items.Find(Query.And(
             Query<YOUR_CLASS>.EQ(x => x._EntityName, "IfcActorRole"),
             Query<YOUR_CLASS>.EQ(x => x.Role, ".SUPPLIER"),
             // other conditions
        ))
