    var documentSerializer = BsonSerializer.SerializerRegistry.GetSerializer<TestObj>();
    var filter = Builders<TestObj>.Filter.Gt(t => t.Age, 20);
    var json = filter
        .Render(documentSerializer, BsonSerializer.SerializerRegistry)
        .ToString();
    // Result:
    // { "Age" : { "$gt" : 20 } }
