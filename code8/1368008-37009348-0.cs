    var mongo_client = new MongoClient();
                var mongo_database = mongo_client.GetDatabase("database_name");
                var collection=mongo_database.GetCollection<BsonDocument>("collection_name");
                using (var cursor = await collection.Find(FilterDefinition<BsonDocument>.Empty).ToCursorAsync())
                {
                    while (await cursor.MoveNextAsync())
                    {
                        foreach (var doc in cursor.Current)
                        {
                            Console.WriteLine(doc);
                        }
                    }
                }
