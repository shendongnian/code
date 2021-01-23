    public interface IResolver 
    {
        void Add<T>(string key, T keyValue);
        T Resolve<T>(string key);
        bool ResolvesAll(params string[] keys);
    }
    public sealed class Resolver : IResolver
    {
        private Dictionary<string, object> directory;
    
        public void Add<T>(string key, T keyValue)
        {
            if (directory.ContainsKey(key))
              directory[key] = keyValue;
            else
              directory.Add(key, keyValue);
        }
    
        public T Resolve<T>(string key) 
        {
            return directory.ContainsKey(key) ? directory[key] as T : default(T);
        }
        public bool ResolvesAll(params string[] keys)
        {
            return keys.All(k => directory.ContainsKey(k));
        }
    }
