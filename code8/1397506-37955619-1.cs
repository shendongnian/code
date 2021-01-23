     MongoClient client = new MongoClient();
                var db = client.GetDatabase("test");
                var collection = db.GetCollection<BsonDocument>("myCollection");
                var filter1 = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId("56d18c7e5e4b3c416e7b408b"));
                using (var cursor = await collection.FindAsync(filter1))
                {
                    while (await cursor.MoveNextAsync())
                    {
                        var batch = cursor.Current;
                        foreach (var document in batch)
                        {
                            int subDocMax = document[1].AsBsonArray.Count;
                            for(int i=0;i<subDocMax;i++)
                            {
                                MessageBox.Show("Name :"+document[1][i][0].ToString());
                            }
                        }
                    }
                }
