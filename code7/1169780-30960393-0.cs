    public sealed class SyncAsyncLazy<T>
    {
      private readonly object _mutex = new object();
      private readonly Func<T> _syncFunc;
      private readonly Func<Task<T>> _asyncFunc;
      private Task<T> _task;
      public SyncAsyncLazy(Func<T> syncFunc, Func<Task<T>> asyncFunc)
      {
        _syncFunc = syncFunc;
        _asyncFunc = asyncFunc;
      }
      public T Get()
      {
        return GetAsync(true).GetAwaiter().GetResult();
      }
      public Task<T> GetAsync()
      {
        return GetAsync(false);
      }
      private Task<T> GetAsync(bool sync)
      {
        lock (_mutex)
        {
          if (_task == null)
            _task = DoGetAsync(sync);
          return _task;
        }
      }
      private async Task<T> DoGetAsync(bool sync)
      {
        return sync ? _syncFunc() : await _asyncFunc().ConfigureAwait(false);
      }
    }
