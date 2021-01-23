    [BsonIgnoreExtraElements]
    class SizeResult
    {
      [BsonElement("size")]
      public long Size { get; set; }
    }
    
    var result = await database.RunCommandAsync<SizeResult>("{collstats: 'collectionName'}");
