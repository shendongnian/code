     public class MongoDbRepository<T> : IRepository<T> where T : IEntityBase
    {
        private IMongoDatabase database;
        private IMongoCollection<T> collection;
        public MongoDbRepository()
        {
            GetDatabase();
            GetCollection();
        }
        private void GetDatabase()
        {
            var client = new MongoClient(GetConnectionString());
            database = client.GetDatabase(GetDatabaseName());
        }
        private void GetCollection()
        {
            collection = database.GetCollection<T>(typeof(T).Name);
        }
        private string GetDatabaseName()
        {
            return ConfigurationManager.AppSettings.Get("MongoDbDatabaseName");
        }
        private string GetConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("MongoDbConnectionString").Replace("{DB_NAME}", GetDatabaseName());
        }
        public async Task<IList<T>> SelectAllSync() 
        {
            //var filter = new BsonDocument("dealer_code", new BsonDocument("$exists", true));
            //var people = await collection.Find<T>(filter).ToListAsync<T>();
            //Search methods
            var result1 = await database.GetCollection<T>(typeof(T).Name)
                                    .Aggregate()
                                    .Match(x => x.last_name.Equals("Hall")).ToListAsync();
            var result2 = collection.FindAsync<T>(Builders<T>
                                .Filter.Eq(x => x.last_name, "Grammer")
                                , new FindOptions<T> { Comment = "TEST" }
                                , CancellationToken.None);
            
           
           
            return (IList<T>)result1;
        }
        public Task Insert(T entity)
        {
            var result = collection.InsertOneAsync(entity);
            return  result;
        }
        public async Task<DeleteResult> Delete(T entity)
        {
            var deleteResult = await collection.DeleteOneAsync(Builders<T>.Filter.Eq(s => s._id, entity._id));
            return deleteResult;
        }
        public async Task<IList<T>> SearchFor(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var result = await database.GetCollection<T>(typeof(T).Name)
                                    .Aggregate()
                                    .Match(predicate).ToListAsync();
            return result;
        }
        public async Task<IList<T>> GetById(ObjectId id)
        {
            var result = await database.GetCollection<T>(typeof(T).Name)
                                    .Aggregate()
                                    .Match(x => x._id.Equals(id)).ToListAsync();
            return result;
        }
        public async Task<UpdateResult> Update(Expression<Func<T, bool>> filter,T entity) 
        {
            if (entity._id == null)
                await Insert(entity);
            
            var list = new List<string>();
            list.Add("dealer_code");
            
            var result = await collection.UpdateOneAsync(
                                    Builders<T>.Filter.Where(filter),
                                    Builders<T>.Update.Set(x=>x.dealer_code, entity.dealer_code));
    
            if (result.IsAcknowledged)
            {
                Console.WriteLine("Success");
            }
            return result;
        }
    }
