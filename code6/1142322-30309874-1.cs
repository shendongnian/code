    try
    {
        commandsCollection.InsertOneAsync(doc).Wait();
    }
    catch(AggregateException aggEx)
    {
        aggEx.Handle(x => 
        { 
            var mwx = x as MongoWriteException;
            if (mwx != null && mwx.WriteError.Category == ServerErrorCategory.DuplicateKey) 
            {
                // mwx.WriteError.Message contains the error message
                return true; 
            }
            return false;
        });
    }
