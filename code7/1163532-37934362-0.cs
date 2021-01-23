             try
                {
                    MongoClient client = new MongoClient("xxx"); 
                    // if you're running localhost let the parameter empty
                    var db = client.GetDatabase("dbName");
                    var collection = db.GetCollection<BsonDocument>("collectionName");
                    var filter1 = Builders<BsonDocument>.Filter.Empty;
                    var filter = new BsonDocument();
                    var count = 0;
                       using (var cursor = await collection.FindAsync(filter))
                        {
                          while (await cursor.MoveNextAsync())
                           {
                            var batch = cursor.Current;
                            foreach (var document in batch)
                            {
                              count++;
                            }
                           }
                        }
                   MessageBox.Show(count.ToString());
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
