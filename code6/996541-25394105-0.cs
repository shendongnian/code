    public class ThreadedQueue<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();
        private readonly ManualResetEvent _notEmptyEvt = new ManualResetEvent(false);
        public WaitHandle WaitHandle { get { return _notEmptyEvt; } }
        public void Enqueue(T obj)
        {
            lock (_queue)
            {
                _queue.Enqueue(obj);
                _notEmptyEvt.Set();
            }
        }
        public T Dequeue()
        {
            _notEmptyEvt.WaitOne(Timeout.Infinite);
            lock (_queue)
            {
                var result = _queue.Dequeue();
                if (_queue.Count == 0)
                    _notEmptyEvt.Reset();
                return result;
            }
        }
    }
