    //user: root  pwd:pwd dbName:admin
      try
      {
        var client = new MongoClient("mongodb://root:pwd@localhost/admin");
        var db = client.GetDatabase("admin");
        foreach (var item in db.ListCollectionsAsync().Result.ToListAsync<BsonDocument>().Result)
         {
                    Console.WriteLine(item.ToString());
         }
      } catch (Exception ex)
      {
        throw ex;
      }
