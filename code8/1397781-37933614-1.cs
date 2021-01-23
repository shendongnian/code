    void ToJsonTyped(BaseObject bo)
    {
      var sb = new StringBuilder();
      using (TextWriter tw = new StringWriter(sb))
      using (BsonWriter bw = new JsonWriter(tw)) 
      {
        BsonSerializer.Serialize<BaseObject>(bw, bo);
      }
      string jsonObject = sb.ToString();
      BaseObject bo2 = BsonSerializer.Deserialize<BaseObject>(jsonObject);
      Assert.AreEqual(bo, bo2);
    }
    void ToBsonTyped(BaseObject bo)
    {
      byte[] bsonObject = null;
      using (var ms = new MemoryStream())
      using (BsonWriter bw = new BsonBinaryWriter(ms))
      {
        BsonSerializer.Serialize<BaseObject>(bw, bo);
        bsonObject = ms.ToArray();
      }
      BaseObject bo1 = BsonSerializer.Deserialize<BaseObject>(bsonObject);
      Assert.AreEqual (bo, bo1);
    }
