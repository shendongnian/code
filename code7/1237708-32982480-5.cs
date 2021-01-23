    public ObservableCollection<BsonType> GetAllFieldTypes(MongoClient client)
    {
        var taskListDB = client.ListDatabasesAsync();
        taskListDB.Wait();
        ObservableCollection<BsonType> allfieldTypes = new ObservableCollection<BsonType>();
        bool end = false;
        do
        {
            var taskMoveNext = taskListDB.Result.MoveNextAsync();
            taskMoveNext.Wait();
    
            allfieldTypes.AsEnumerable<BsonType>().ToList().AddRange(taskListDB.Result.Current.FirstOrDefault().Elements.Select(e => e.Value.BsonType).ToList());
    
            end = taskMoveNext.Result;
        } while (end);
        return allfieldTypes;
    }
