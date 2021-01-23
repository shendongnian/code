    class Program
    {
        static void Main(string[] args)
        {
            var mop = new MonoObjectPool();
            mop.Pool = new ObjectPool<IDbConnection>(() => new SqlConnection("Data Source=server1"));
            var service = new Service();
            mop.Pool = new ObjectPool<IDbConnection>(() => new SqlConnection("Data Source=server2"));
            Console.WriteLine(service.Pool.GetObject().ConnectionString);
        }
    }
    internal class MonoObjectPool
    {
        private static ObjectPool<IDbConnection> pool1;
        public ObjectPool<IDbConnection> Pool
        {
            get { return pool1; }
            set { pool1 = value; }
        }
    }
    class Service
    {
        public ObjectPool<IDbConnection> Pool { get { return new MonoObjectPool().Pool; } }
    }
