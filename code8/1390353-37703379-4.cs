    public interface ICacheProvider
    {
        object Get(string key);
        bool Set(string key, object value, TimeSpan expiration);
    }
