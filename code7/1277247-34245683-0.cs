    class BlockingPredicateCollection<T>
    {
        private readonly object _lock = new object();
        private readonly List<T> _list = new List<T>();
        public void Add(T t)
        {
            lock (_lock)
            {
                _list.Add(t);
                // Wake any waiting threads, so they can check if the element they
                // are waiting for is now present.
                Monitor.PulseAll(_lock);
            }
        }
        public bool TryTake(out T t, Predicate<T> predicate, TimeSpan timeout)
        {
            Stopwatch sw = Stopwatch.StartNew();
            lock (_lock)
            {
                int index;
                while ((index = _list.FindIndex(predicate)) < 0)
                {
                    TimeSpan elapsed = sw.Elapsed;
                    if (elapsed > timeout ||
                        !Monitor.Wait(_lock, timeout - elapsed))
                    {
                        t = default(T);
                        return false;
                    }
                }
                t = _list[index];
                _list.RemoveAt(index);
                return true;
            }
        }
    }
