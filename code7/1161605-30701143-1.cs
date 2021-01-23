    class PreBufferingEnumerator<TItem> : IEnumerator<TItem>
    {
        private readonly IEnumerator<TItem> _underlying;
        private readonly int _bufferSize;
        private readonly Queue<TItem> _buffer;
        private bool _done;
        private bool _disposed;
        public PreBufferingEnumerator(IEnumerator<TItem> underlying, int bufferSize)
        {
            _underlying = underlying;
            _bufferSize = bufferSize;
            _buffer = new Queue<TItem>();
            Thread preBufferingThread = new Thread(PreBufferer) { Name = "PreBufferingEnumerator.PreBufferer", IsBackground = true };
            preBufferingThread.Start();
        }
        private void PreBufferer()
        {
            while (true)
            {
                lock (_buffer)
                {
                    while (_buffer.Count == _bufferSize && !_disposed)
                        Monitor.Wait(_buffer);
                    if (_disposed)
                        return;
                }
                if (!_underlying.MoveNext())
                {
                    lock (_buffer)
                        _done = true;
                    return;
                }
                var current = _underlying.Current; // do outside lock, in case underlying enumerator does something inside get_Current()
                lock (_buffer)
                {
                    _buffer.Enqueue(current);
                    Monitor.Pulse(_buffer);
                }
            }
        }
        public bool MoveNext()
        {
            lock (_buffer)
            {
                while (_buffer.Count == 0 && !_done && !_disposed)
                    Monitor.Wait(_buffer);
                if (_buffer.Count > 0)
                {
                    Current = _buffer.Dequeue();
                    Monitor.Pulse(_buffer); // so PreBufferer thread can fetch more
                    return true;
                }
                return false; // _done || _disposed
            }
        }
        public TItem Current { get; private set; }
        public void Dispose()
        {
            lock (_buffer)
            {
                if (_disposed)
                    return;
                _disposed = true;
                _buffer.Clear();
                Current = default(TItem);
                Monitor.PulseAll(_buffer);
            }
        }
