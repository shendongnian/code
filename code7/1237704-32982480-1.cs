    ObservableCollection<string> fieldNames;
     
    public void AddFieldName(string newFieldName)
    {
        if ((fieldNames != null) && (fieldNames.Contains(newFieldName))) { return; }
        IMongoCollection<BsonDocument> collection;
        // Get the collection of your database
     
        var filter = Builders<BsonDocument>.Filter.Exists("_id", true);
        var update = Builders<BsonDocument>.Update.Set(newFieldName, "");
        if (fieldNames == null)
        {// Initialize with existing field names
            InitFieldNames(collection, filter);
        }
        var updateResultTask = collection.UpdateManyAsync(filter, update);
        updateResultTask.Wait();
     
        fieldNames.Add(newFieldName);
    }
     
    private void InitFieldNames(IMongoCollection<BsonDocument> collection, FilterDefinition<BsonDocument> filter)
    {
        fieldNames = new ObservableCollection<string>();
        var findTask = collection.Find<BsonDocument>(filter).FirstOrDefaultAsync();
        findTask.Wait();
        findTask.Result.Elements.Select(e => e.Name).ToList().ForEach(n => fieldNames.Add(n));
    }
