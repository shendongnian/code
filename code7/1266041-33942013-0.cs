    public sealed class TooLazy<T>
    {
        private readonly object _lock = new object();
        private readonly Func<Task<T>> _factory;
        private Task<T> _cached;
        public TooLazy(Func<Task<T>> factory)
        {
            if (factory == null) throw new ArgumentNullException("factory");
            _factory = factory;
        }
        public Task<T> Value
        {
            get
            {
                lock (_lock)
                {
                    if ((_cached == null) ||
                        (_cached.IsCompleted && (_cached.Status != TaskStatus.RanToCompletion)))
                    {
                        _cached = Task.Run(_factory);
                    }
                    return _cached;
                }
            }
        }
    }
