    void ToBsonUnTyped(BsonDocument doc) {
      byte[] bsonObject = null;
      using (var ms = new MemoryStream())
      using (BsonWriter bw = new BsonBinaryWriter(ms))
      {
        BsonSerializer.Serialize<BsonDocument>(bw, doc);
        bsonObject = ms.ToArray();
      }
      BsonDocument docActual = BsonSerializer.Deserialize<BsonDocument>(bsonObject);
      Assert.AreEqual (doc, docActual);
    }
    void ToJsonUnTyped(BsonDocument doc)
    {
      var sb = new StringBuilder();
      using (TextWriter tw = new StringWriter(sb))
      using (BsonWriter bw = new JsonWriter(tw))
      {
        BsonSerializer.Serialize<BsonDocument>(bw, doc);        
      }
      string jsonObject = sb.ToString();
      BsonDocument doc2 = BsonSerializer.Deserialize<BsonDocument>(jsonObject);
      Assert.AreEqual(doc, doc2);
    }
