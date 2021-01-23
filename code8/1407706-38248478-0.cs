    public interface IDbQuerier
    {
        void Run();
    }
    public abstract class BaseDbQuerier : IDbQuerier
    {
        private static IDictionary<DbEnum, string> _connections;
        static BaseDbQuerier()
        {
            _connections = // Load connection strings from configuration
        }
        protected abstract DbEnum Database { get; }
        public void Run()
        {
            string connectionString = _connections[Database];
            // DbQuerier logic
        }
    }
    public enum DbEnum
    {
        CatDatabase,
        DogDatabase,
        TurtleDatabase
    }
