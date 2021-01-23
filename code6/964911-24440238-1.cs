    public class ThreadLocalDisposable<T> : IDisposable
        where T : IDisposable
    {
        private readonly ConcurrentDictionary<Thread, T> valuesByThread
            = new ConcurrentDictionary<Thread, T>();
        private readonly Func<T> factoryMethod;
        private object disposedLock = new object();
        private bool disposed = false;
        public ThreadLocalDisposable(
            Func<T> factoryMethod,
            Action<T> cleanupMethod)
        {
            if (factoryMethod == null) throw new ArgumentNullException("factoryMethod");
            if (cleanupMethod == null) throw new ArgumentNullException("cleanupMethod");
            this.factoryMethod = factoryMethod;
            var disposerThread = new Thread(() =>
            {
                bool exit = false;
                while (!exit)
                {
                    Thread.Sleep(1000);
                    var removedValuesByThread = new List<KeyValuePair<Thread, T>>();
                    foreach (var valueByThread in this.valuesByThread)
                    {
                        if ((valueByThread.Key.ThreadState & ThreadState.Stopped) == ThreadState.Stopped)
                        {
                            removedValuesByThread.Add(valueByThread);
                        }
                    }
                    foreach (var removedValueByThread in removedValuesByThread)
                    {
                        T value;
                        while (!this.valuesByThread.TryRemove(removedValueByThread.Key, out value))
                        {
                            Thread.Sleep(2);
                        }
                        cleanupMethod(value);
                    }
                    lock (this.disposedLock)
                    {
                        exit = this.disposed;
                    }
                }
                foreach (var valueByThread in this.valuesByThread)
                {
                    var value = valueByThread.Value;
                    cleanupMethod(value);
                }
                this.valuesByThread.Clear();
            });
            disposerThread.Start();
        }
        public T Value
        {
            get
            {
                if (!this.valuesByThread.ContainsKey(Thread.CurrentThread))
                {
                    var newValue = this.factoryMethod();
                    while (!this.valuesByThread.TryAdd(Thread.CurrentThread, newValue))
                    {
                        Thread.Sleep(2);
                    }
                }
                var result = this.valuesByThread[Thread.CurrentThread];
                return result;
            }
        }
        public void Dispose()
        {
            lock (this.disposedLock)
            {
                this.disposed = true; // tells disposer thread to shut down
            }
        }
    }
