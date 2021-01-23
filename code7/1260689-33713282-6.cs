    class SynchronousProgress<T> : IProgress<T>
    {
        public event EventHandler<T> ProgressChanged;
        public SynchronousProgress() { }
        public SynchronousProgress(Action<T> callback)
        {
            ProgressChanged = (sender, e) => callback(e);
        }
        public void Report(T t)
        {
            EventHandler<T> handler = ProgressChanged;
            if (handler != null)
            {
                handler(this, t);
            }
        }
    }
