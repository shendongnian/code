    public sealed class CollectionWatcher<T>
    {
        private readonly Func<T> _objectFactory;
        private readonly List<WeakReference> _references;
        private readonly System.Timers.Timer _timer;
        private readonly Object _lockObject = new Object();
        public CollectionWatcher(Func<T> objectFactory, double minutesBetweenChecks = 5)
        {
            _objectFactory = objectFactory;
            _references = new List<WeakReference>();
            _timer = new System.Timers.Timer();
            _timer.Interval = TimeSpan.FromMinutes(minutesBetweenChecks).TotalMilliseconds;
            _timer.AutoReset = true;
            _timer.Elapsed += TimerElapsed;
        }
        public T GetObjectBecauseICantBeTrustedToDisposeCorrectly()
        {
            var result = _objectFactory();
            var wr = new WeakReference(result);
            lock (_lockObject)
            {
                _references.Add(wr);
                _timer.Start();
            }
            return result;
        }
        public event EventHandler AllItemsCollected;
        private void OnAllItemsCollected()
        {
            AllItemsCollected?.Invoke(this, EventArgs.Empty);
        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            bool allItemCollected = false;
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, false);
            lock (_lockObject)
            {
                foreach (var reference in _references.Where(x => !x.IsAlive).ToList())
                {
                    _references.Remove(reference);
                }
                if (_references.Count == 0)
                {
                    _timer.Stop();
                    allItemCollected = true;
                }
            }
            if (allItemCollected)
            {
                OnAllItemsCollected();
            }
        }
    }
