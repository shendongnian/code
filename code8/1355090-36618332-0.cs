    var coll = database.GetCollection<BsonDocument>("Footballers");
            var documents = coll.Find(new BsonDocument()).ToList();
            for(int i=0; i<documents.Count(); i++){
                Console.WriteLine(documents[i]);
            }
            Console.ReadLine();
