            class TestModel
            {
               public string Name {get;set;}
    
               [BsonIgnore]
               public string IgnoreThis{get;set;}
    
               [BsonId]
               [BsonRepresentation(BsonType.ObjectId)]
               public string Id { get; set; }
    }
