    public sealed class AsyncLazy<T>
    {
        private readonly Lazy<Task<T>> instance;
        ...
        public bool IsValueCreated
        {
            get { return instance.IsValueCreated; }
        }
    }
