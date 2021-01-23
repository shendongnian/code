    using System;
    using System.Runtime.Caching;
    using System.Threading;
    public interface IMicroCache<T>
    {
        bool Contains(string key);
        T GetOrAdd(string key, Func<T> loadFunction, Func<CacheItemPolicy> getCacheItemPolicyFunction);
        void Remove(string key);
    }
    public class MicroCache<T> : IMicroCache<T>
    {
        public MicroCache(ObjectCache objectCache)
        {
            if (objectCache == null)
                throw new ArgumentNullException("objectCache");
            this.cache = objectCache;
        }
        private readonly ObjectCache cache;
        private ReaderWriterLockSlim synclock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        public bool Contains(string key)
        {
            synclock.EnterReadLock();
            try
            {
                return this.cache.Contains(key);
            }
            finally
            {
                synclock.ExitReadLock();
            }
        }
        public T GetOrAdd(string key, Func<T> loadFunction, Func<CacheItemPolicy> getCacheItemPolicyFunction)
        {
            LazyLock<T> lazy;
            bool success;
            synclock.EnterReadLock();
            try
            {
                success = this.TryGetValue(key, out lazy);
            }
            finally
            {
                synclock.ExitReadLock();
            }
            if (!success)
            {
                synclock.EnterWriteLock();
                try
                {
                    if (!this.TryGetValue(key, out lazy))
                    {
                        lazy = new LazyLock<T>();
                        var policy = getCacheItemPolicyFunction();
                        this.cache.Add(key, lazy, policy);
                    }
                }
                finally
                {
                    synclock.ExitWriteLock();
                }
            }
            return lazy.Get(loadFunction);
        }
        public void Remove(string key)
        {
            synclock.EnterWriteLock();
            try
            {
                this.cache.Remove(key);
            }
            finally
            {
                synclock.ExitWriteLock();
            }
        }
        private bool TryGetValue(string key, out LazyLock<T> value)
        {
            value = (LazyLock<T>)this.cache.Get(key);
            if (value != null)
            {
                return true;
            }
            return false;
        }
        private sealed class LazyLock<T>
        {
            private volatile bool got;
            private T value;
            public T Get(Func<T> activator)
            {
                if (!got)
                {
                    if (activator == null)
                    {
                        return default(T);
                    }
                    lock (this)
                    {
                        if (!got)
                        {
                            value = activator();
                            got = true;
                        }
                    }
                }
                return value;
            }
        }
    }
