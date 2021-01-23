    public interface ICache
    {
        void Add<T>(string key, TimeSpan lifetime, T value);
        bool TryGet<T>(string key, out T value);
        void Remove(string key);
        . . .
    }
