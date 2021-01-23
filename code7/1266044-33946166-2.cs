    // http://stackoverflow.com/a/33872589/11635
    public class LazyTask
    {
        public static LazyTask<T> Create<T>(Func<Task<T>> factory)
        {
            return new LazyTask<T>(factory);
        }
    }
    /// <summary>
    /// Implements a caching/provisioning model we can term LazyThreadSafetyMode.ExecutionAndPublicationWithoutFailureCaching
    /// - Ensures only a single provisioning attempt in progress
    /// - a successful result gets locked in
    /// - a failed result triggers replacement by the first caller through the gate to observe the failed state
    ///</summary>
    /// <remarks>
    /// Inspired by Stephen Toub http://blogs.msdn.com/b/pfxteam/archive/2011/01/15/asynclazy-lt-t-gt.aspx
    /// Implemented with sensible semantics by @LukeH via SO http://stackoverflow.com/a/33942013/11635
    /// </remarks>
    public class LazyTask<T>
    {
        readonly object _lock = new object();
        readonly Func<Task<T>> _factory;
        Task<T> _cached;
        public LazyTask(Func<Task<T>> factory)
        {
            if (factory == null) throw new ArgumentNullException("factory");
            _factory = factory;
        }
        /// <summary>
        /// Allow await keyword to be applied directly as if it was a Task<T>. See Value for semantics.
        /// </summary>
        public TaskAwaiter<T> GetAwaiter()
        {
            return Value.GetAwaiter();
        }
        /// <summary>
        /// Trigger a load attempt. If there is an attempt in progress, take that. If preceding attempt failed, trigger a retry.
        /// </summary>
        public Task<T> Value
        {
            get
            {
                lock (_lock)
                {
                    if (_cached == null
                        // Iff we're the first to see the shared/cached attempt ended up failing
                        || (_cached.IsCompleted && _cached.Status != TaskStatus.RanToCompletion))
                        // (re)trigger an attempt to create
                        _cached = Task.Run(_factory);
                    return _cached;
                }
            }
        }
    }
