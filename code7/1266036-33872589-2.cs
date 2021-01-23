    public class CachedAsync<T>
    {
        readonly Func<Task<T>> _taskFactory;
        T _value;
        public CachedAsync(Func<Task<T>> taskFactory)
        {
            _taskFactory = taskFactory;
        }
        public TaskAwaiter<T> GetAwaiter() { return Fetch().GetAwaiter(); }
        async Task<T> Fetch()
        {
            if (_value == null)
                _value = await _taskFactory();
            return _value;
        }
    }
