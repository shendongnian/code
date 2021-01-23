    var docs = new Dictionary<string, BsonDocument>();
    var result = collection.Find(filter).Project(projection);      
    result.ForEachAsync((bsonDoc) =>
    {
        string name = bsonDoc.GetValue("[Your Dictionary Key]").AsString;
        if (!docs.ContainsKey(name))
        {
            docs[name] = bsonDoc;
        }
    });
