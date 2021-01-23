    public class Core
    {
        private static readonly Core instance = new Core();
        private Dictionary<Type, object> container;
        private Core()
        {
            container = new Dictionary<Type, object>();
        }
        public void RegisterSingleton<T>(T value) where T : class
        {
            Type type = typeof(T);
            if (!container.ContainsKey(type))
                container.Add(type, value);
        }
        public T GetSingleton<T>() where T : class
        {
            Type type = typeof(T);
            if (container.ContainsKey(type))
                return (T)container[type];
            else
                throw new Exception("Singleton instance not registered.");
        }
        public void RemoveSingleton<T>() where T : class
        {
            Type type = typeof(T);
            if (container.ContainsKey(type))
                container.Remove(type);
        }
        public void ClearSingletons()
        {
            container.Clear();
        }
        public static Core Instance
        {
            get { return instance; }
        }
    }
