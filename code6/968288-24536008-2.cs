    class Program
    {
        static void Main(string[] args)
        {
            var pool1 = new ObjectPool<IDbConnection>(() => new SqlConnection("Data Source=server1"));
            var service = new Service(ref pool1);
            pool1 = new ObjectPool<IDbConnection>(() => new SqlConnection("Data Source=server2"));
            Console.WriteLine(service.Pool.GetObject().ConnectionString);
        }
    }
    class Service
    {
        private ObjectPool<IDbConnection> connectionPool;
        public Service(ref ObjectPool<IDbConnection> pool) { this.connectionPool = pool; }
        public ObjectPool<IDbConnection> Pool { get { return connectionPool; }  }
    }
