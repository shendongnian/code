    public class Zoo
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public List<Animal> Animals { get; set; }
    }
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(Tiger), typeof(Zebra))]
    public class Animal
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
    public class Tiger : Animal
    {
        public double Height { get; set; }
    }
    public class Zebra : Animal
    {
        public long StripesAmount { get; set; }
    }
    public class MongoDocumentsDatabase
    {
        /// <summary>
        /// MongoDB Server
        /// </summary>
        private readonly MongoClient _client;
        /// <summary>
        /// Name of database 
        /// </summary>
        private readonly string _databaseName;
        public MongoUrl MongoUrl { get; private set; }
        /// <summary>
        /// Opens connection to MongoDB Server
        /// </summary>
        public MongoDocumentsDatabase(String connectionString)
        {
            MongoUrl = MongoUrl.Create(connectionString);
            _databaseName = MongoUrl.DatabaseName;
            _client = new MongoClient(connectionString);
        }
        /// <summary>
        /// Get database
        /// </summary>
        public IMongoDatabase Database
        {
            get { return _client.GetDatabase(_databaseName); }
        }
        public IMongoCollection<Zoo> Zoo { get { return Database.GetCollection<Zoo>("zoo"); } }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString =
                "mongodb://admin:admin@localhost:27017/testDatabase";
            var pr = new Program();
            pr.Save(connectionString);
            var zoo = pr.Get(connectionString);
            foreach (var animal in zoo.Animals)
            {
                Console.WriteLine(animal.Name + "  " + animal.GetType());
            }
        }
        public void Save(string connectionString)
        {
            var zoo = new Zoo
            {
                Animals = new List<Animal>
                {
                    new Tiger
                    {
                        Height = 1,
                        Name = "Tiger1"
                    },
                    new Zebra
                    {
                        Name = "Zebra1",
                        StripesAmount = 100
                    }
                }
            };
            var database = new MongoDocumentsDatabase(connectionString);
            database.Zoo.InsertOneAsync(zoo).Wait();
        }
        public Zoo Get(string connectionString)
        {
            var database = new MongoDocumentsDatabase(connectionString);
            var task = database.Zoo.Find(e => true).SingleAsync();
            task.Wait();
            return task.Result;
        }
    }
