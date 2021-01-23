    public sealed class AsyncDuplicateLock
    {
        private class LockInfo
        {
            private SemaphoreSlim sem;
            private int waiterCount;
            public LockInfo()
            {
                sem = null;
                waiterCount = 1;
            }
            // Lazily create the semaphore
            private SemaphoreSlim Semaphore
            {
                get
                {
                    var s = sem;
                    if (s == null)
                    {
                        s = new SemaphoreSlim(0, 1);
                        var original = Interlocked.CompareExchange(ref sem, null, s);
                        // If someone else already created a semaphore, return that one
                        if (original != null)
                            return original;
                    }
                    return s;
                }
            }
            // Returns true if successful
            public bool Enter()
            {
                if (Interlocked.Increment(ref waiterCount) > 1)
                {
                    Semaphore.Wait();
                    return true;
                }
                return false;
            }
            // Returns true if this lock info is now ready for removal
            public bool Exit()
            {
                if (Interlocked.Decrement(ref waiterCount) <= 0)
                    return true;
                // There was another waiter
                Semaphore.Release();
                return false;
            }
        }
        private static readonly ConcurrentDictionary<object, LockInfo> activeLocks = new ConcurrentDictionary<object, LockInfo>();
        public static IDisposable Lock(object key)
        {
            // Get the current info or create a new one
            var info = activeLocks.AddOrUpdate(key,
              (k) => new LockInfo(),
              (k, v) => v.Enter() ? v : new LockInfo());
            DisposableScope releaser = new DisposableScope(() =>
            {
                if (info.Exit())
                {
                    // Only remove this exact info, in case another thread has
                    // already put its own info into the dictionary
                    ((ICollection<KeyValuePair<object, LockInfo>>)activeLocks)
                      .Remove(new KeyValuePair<object, LockInfo>(key, info));
                }
            });
            return releaser;
        }
        private sealed class DisposableScope : IDisposable
        {
            private readonly Action closeScopeAction;
            public DisposableScope(Action closeScopeAction)
            {
                this.closeScopeAction = closeScopeAction;
            }
            public void Dispose()
            {
                this.closeScopeAction();
            }
        }
    }
