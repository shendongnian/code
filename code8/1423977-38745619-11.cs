    public class StubCache<T> : ICache
    {
        public bool TryGetResult { get; set; }
        public T TryGetValue { get; set; }
        public T AddValue { get; set; }
        public TimeStamp LifeTimeValue { get; set; }
        void Add<T>(string key, TimeSpan lifetime, T value)
        {
            LifeTimeValue = lifetime;
            AddValue = value;
        }
        bool TryGet<T>(string key, out T value)
        {
            value = TryGetValue;
            return TryGetResult;
        }
        . . .
    }
