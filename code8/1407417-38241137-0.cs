            var count = collection.Find(new BsonDocument()).Count();
            var stepSize = 1000;
            for (int i = 0; i < Math.Ceiling((double)count / stepSize); i++)
            {
                // put your query here      \/\/\/\/\/\/
                var list = collection.Find(new BsonDocument()).Skip(i * stepSize).Limit(stepSize).ToList();
                // process the 1000 ...
            }
