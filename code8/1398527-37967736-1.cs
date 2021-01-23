        public static void Main()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("hammer");
            var project =
                BsonDocument.Parse(
                    "{_id: 1,address: 1,borough: 1,cuisine: 1,grades: 1,name: 1,restaurant_id: 1,year: {$year: '$grades.date'}}");
            var aggregationDocument =
                collection.Aggregate()
                    .Unwind("grades")
                    .Project(project)
                    .Match(BsonDocument.Parse("{'year' : {$in : [2013, 2015]}}"))
                    .ToList();
            foreach (var result in aggregationDocument)
            {
                Console.WriteLine(result.ToString());
            }
            Console.ReadLine();
        }
