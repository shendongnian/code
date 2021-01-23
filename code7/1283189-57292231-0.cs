    public class AtomicLazy<T>
    {
        private readonly Func<T> _factory;
        private T _value;
        private bool _initialized;
        private object _lock;
        public AtomicLazy(Func<T> factory)
        {
            _factory = factory;
        }
        public T Value => LazyInitializer.EnsureInitialized(ref _value, ref _initialized, ref _lock, _factory);
    }
