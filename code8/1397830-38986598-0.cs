    public abstract class CtrlBase : ApiController
    {
        private IMongoDatabase _db = null;
        protected IMongoDatabase DB
        {
            get
            {
                if (_db == null)
                {
                    var cred = MongoCredential.CreateCredential("user", "password");
                    var sett = new MongoClientSettings
                    {
                        Server = new MongoServerAddress("server", <port>),
                        Credentials = new List<MongoCredential> { cred }
                    };
                    var client = new MongoClient(sett);
                    _db = client.GetDatabase("dbName");
                }
                return _db;
            }
        }
    
        protected IMongoCollection<Thing> Things
        {
            get { return DB.GetCollection<Thing>("mythings"); }
        }
    
    }
