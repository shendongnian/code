    //Get all documents
    var f = Builders<BsonDocument>.Filter.Empty;
    //Just pull itemID
    var p = Builders<BsonDocument>.Projection.Include(x => x["itemID"]);
    //Sort ascending by itemID
    var s = Builders<BsonDocument>.Sort.Ascending("itemID");
    //Apply the builders, and then use the Select method to pull up the itemID's as ints
    var found = collection.Find(f)
            .Project<BsonDocument>(p)
            .Sort(s)
            .ToList()
            .Select(x=>x["itemID"].AsInt32)
            .ToArray();
