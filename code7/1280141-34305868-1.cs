    static class DatabaseManager
    {
        private static Dictionary<Type, object> databases = new Dictionary<Type, object>();
        // ....
        public static Database<T> GetDatabase<T>()
            where T : DatabaseItem, new()
        {
            return (Database<T>)databases[typeof(T)];
        }
    }
