    class MyClass : IDisposable
    {
        volatile bool working;
        public MyClass()
        {
            working = true;
            Thread t = new Thread(Worker);
            t.Start(new WeakReference(this));
        }
        void Worker(object state)
        {
            var r = (WeakReference)state;
            while (working && r.IsAlive)
            {
                ...
            }
        }
        public void Dispose()
        {
            working = false;
        }
    }
