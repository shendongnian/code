     try
            {
                MongoClient client = new MongoClient();
                var db = client.GetDatabase("test");
                var collection = db.GetCollection<BsonDocument>("myCollection");
                var builder = Builders<BsonDocument>.Filter;
                var filter1 = builder.Eq("_id", "1db5b191-c6d5-47ea-90ef-98202f604a6b");
                using (var cursor = await collection.FindAsync(filter1))
                {
                    while (await cursor.MoveNextAsync())
                    {
                        var batch = cursor.Current;
                        foreach (var document in batch)
                        {
                            
                                MessageBox.Show("entity name: " + document[2].ToString());
                                MessageBox.Show("role :" + document[3].ToString());
                                MessageBox.Show("user defined role :" + document[4].ToString());
                                MessageBox.Show("description :" + document[5].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
