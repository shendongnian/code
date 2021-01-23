    public class StubCache : ICache
    {
        public bool TryGetResult { get; set; }
        public bool TryGetValue { get; set; }
        public bool AddValue { get; set; }
        public TimeStamp LifeTimeValue { get; set; }
        void Add<T>(string key, TimeSpan lifetime, T value)
        {
            LifeTimeValue = lifetime;
            AddValue = (bool)(object)value;
        }
        bool TryGet<T>(string key, out T value)
        {
            value = (T)(object)TryGetValue;
            return TryGetResult;
        }
        . . .
    }
