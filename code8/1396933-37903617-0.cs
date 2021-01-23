    public Interface IEntity
    {
        int Id {set ;get}
    }
    class EntryManagement<T> where T : IEntity
    {
        public T GetEntry(ObjectId id)
        {
            IMongoCollection<T> collections = db.GetCollection<T>(database);
            var getObj = collections.Find(x => x.Id == id).FirstOrDefault();      
            return getObj;
         }
    }
