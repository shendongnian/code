    var pipeline = new BsonDocument[0]; // replace with a real pipeline
    var aggregateArgs = new AggregateArgs { AllowDiskUse = true, Pipeline = pipeline };
    var aggregateResult = collection.Aggregate(aggregateArgs);
    var users = aggregateResult.Select(x =>
        new User
        {
            Influence = x["Influence"].ToDouble(),
            User = new SMBUser(x["user"].AsBsonDocument)
        }).ToList();
