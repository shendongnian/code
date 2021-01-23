                string line;
                using (TextReader file = File.OpenText("ImportDataFromBJsonFile\\a.json"))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        var bsonDocument = BsonDocument.Parse(line);
                        var myObj = BsonSerializer.Deserialize<Zxed>(bsonDocument);
                    }
                }
