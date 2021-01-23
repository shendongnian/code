    public class MongoRepository<T>
	{
        protected IMongoCollection<T> _collection;
        public MongoRepository(string collectionName) 
        {
            // Get your mongo client and database objects here.
            _collection = _mongoDb.GetCollection<T>(collectionName);
        }
        public async Task<IList<T>> Find(Expression<Func<T, bool>> query)
		{
			// Return the enumerable of the collection
			return await _collection.Find<T>(query).ToListAsync();
		}
    }
