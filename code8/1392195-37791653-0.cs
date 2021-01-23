    namespace ProjectA.B.C
    {
        class Caching
        {
            public static bool GetOrSet<T>(string key, Func<T> getValue, out T value, TimeSpan? expiration = null) {
                ...
            }
            public static bool Get<T>(string key, out T value) {
                ...
            }
        }
    }
