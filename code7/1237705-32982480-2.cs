    public void GetAllFieldTypes(IMongoCollection<BsonDocument> collection)
    {
        ObservableCollection<BsonType> fieldTypes = new ObservableCollection<BsonType>();
    
        var filter = Builders<BsonDocument>.Filter.Exists("_id", true);
        var findTask = collection.Find<BsonDocument>(filter).FirstOrDefaultAsync();
        findTask.Wait();
        findTask.Result.Elements.Select(e => e.Value.BsonType).ToList().ForEach(b => fieldTypes.Add(b));
        return fieldTypes;
    }
     
