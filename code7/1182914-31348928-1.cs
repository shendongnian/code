    class MyClass : IDisposable
    {
        class CancellationSignal
        {
            WeakReference _reference;
            public bool IsWorking { get { return _working && _reference.IsAlive; } }
            volatile bool _working;
            public CancellationSignal(WeakReference reference)
            {
                if (reference == null) throw new ArgumentNullException("reference");
                _reference = reference;
            }
            public void Stop()
            {
                _working = false;
            }
        }
        CancellationSignal _cancellationSignal;
        public MyClass()
        {
            _cancellationSignal = new CancellationSignal(new WeakReference(this));
            Thread t = new Thread(Worker);
            t.Start(_cancellationSignal);
        }
        static void Worker(object state)
        {
            var s = (CancellationSignal)state;
            while (s.IsWorking)
            {
                //...
            }
        }
        public void Dispose()
        {
            _cancellationSignal.Stop();
        }
    }
