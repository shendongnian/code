    services.AddSingleton(typeof(IMongoCollection<>), typeof(MongoCollectionFactory<>)); //this is the important part
    services.AddSingleton(typeof(IRepository<>), typeof(Repository<>))
    
    public class Repository : IRepository {
        private readonly IMongoCollection _collection;
        public Repository(IMongoCollection collection)
        {
            _collection = collection;
        }
        // .. rest of the implementation
    }
    //and this is important as well
    public class MongoCollectionFactory<T> : IMongoCollection<T> {
        private readonly _collection;
        public RepositoryFactoryAdapter(IMongoDatabase database) {
            // do the factory work here
            _collection = database.GetCollection<T>(typeof(T).Name.ToLowerInvariant())
        }
        public T Find(string id) 
        {
            return collection.Find(id);
        }   
        // ... etc. all the remaining members of the IMongoCollection<T>, 
        // you can generate this easily with ReSharper, by running 
        // delegate implementation to a new field refactoring
    }
