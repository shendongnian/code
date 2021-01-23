    try
    {
        commandsCollection.InsertOneAsync(doc).GetAwaiter().GetResult();
    }
    catch(MongoWriteException mwx)
    {
        if (mwx != null && mwx.WriteError.Category == ServerErrorCategory.DuplicateKey) 
        {
            // mwx.WriteError.Message contains the duplicate key error message
        }
    }
