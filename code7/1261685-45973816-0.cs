            using (IAsyncCursor<BsonDocument> dbCursor = client.ListDatabases())
            {
                while (dbCursor.MoveNext())
                {
                    foreach (var dbDoc in dbCursor.Current)
                    {
                        Console.WriteLine("-----{0}-----", dbDoc["name"]);
                        var dbName = dbDoc["name"].ToString();  // list database name
                        using (IAsyncCursor<BsonDocument> collectionCursor = client.GetDatabase(dbName).ListCollections())
                        {
                            while (collectionCursor.MoveNext())
                            {
                                foreach (var collDoc in collectionCursor.Current)
                                {
                                    Console.WriteLine(collDoc["name"]);  // list collection name
                                }
                            }
                        }
                    }
                }
            }
