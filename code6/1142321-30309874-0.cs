    try
    {
        commandsCollection.InsertOneAsync(doc).Wait();
    }
    catch(AggregateException aggEx)
    {
        ... handle it
    }
