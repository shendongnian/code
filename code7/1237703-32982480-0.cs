    ObservableCollection<string> fieldNames;
     
    public void AddFieldName(string newFieldName)
    {
        if (fieldNames.Contains(newFieldName)) { return; }
        IMongoCollection<T> collection;
        // Get a collection
     
        var filter = Builders<BsonDocument>.Filter.Exists("_id", true);
        var update = Builders<BsonDocument>.Update.Set(newFieldName, "");
        var updateResultTask = collection.UpdateManyAsync(filter, update);
        updateResultTask.Wait();
     
        fieldNames.Add(newFieldName);
    }
