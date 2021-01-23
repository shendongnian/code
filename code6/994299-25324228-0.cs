    var food = server.GetDatabase("food", credentials);
    var col = db.GetCollection<RawBsonDocument>("bar");
    foreach (var doc in col.Find(
        Query.And(
            Query.GTE("min_price", 1),
            Query.LTE("max_price", 50),
            Query.In("food", new [] { (BsonValue)"sausage", (BsonValue)"burger" }),
            Query.In("location", new [] { (BsonValue)"new york", (BsonValue)"chicago" })
        ))
    )
    {
        // handle found doc here
    }
