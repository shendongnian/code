    public interface ICacheProvider
    {
        T Get<T>(string key);
        bool Set<T>(string key, T value, TimeSpan expiration);
    }
