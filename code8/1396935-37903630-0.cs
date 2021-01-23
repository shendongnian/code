    public T GetEntry<T>(ObjectId id, Expression<Func<T, bool>> predicate)
    {
        IMongoCollection<T> collections = db.GetCollection<T>(database);
        var getObj = collections.Find(predicate).FirstOrDefault(); // Call passed in predicate
        return getObj;
    }
