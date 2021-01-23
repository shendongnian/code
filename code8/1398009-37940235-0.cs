    public async Task SaveDataTableToCollection(DataTable dt)
          {
              var connectionString = ConfigurationManager.AppSettings["mongoConnection"];
              var client = new MongoClient(connectionString);
              var database = client.GetDatabase("myMongoDatabaseName");
     
              var collection = database.GetCollection<BsonDocument>("MyCollection");
     
              List<BsonDocument> batch = new List<BsonDocument>();
              foreach (DataRow dr in dt.Rows)
              {
                  var dictionary = dr.Table.Columns.Cast<DataColumn>().ToDictionary(col => col.ColumnName, col => dr[col.ColumnName]);
                  batch.Add(new BsonDocument(dictionary));
              }
     
              await collection.InsertManyAsync(batch.AsEnumerable());
          }
