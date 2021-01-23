    public class FixedQueue<T>
    {
        private readonly ConcurrentQueue<T> _innerQueue;
        private int _length;
        public FixedQueue(int length)
        {
            _length = length;
            _innerQueue = new ConcurrentQueue<T>(length);
        }  
        
        public void Enqueue(T obj)
        {
            lock (_innerQueue)
            {
                if (_innerQueue.Length == _length)
                    _innerQueue.Dequeue();
                _innerQueue.Enqueue(obj);
            }
        }
        public T Dequeue()
        {
            lock (_innerQueue)
            {
                return _innerQueue.Dequeue();
            }
        }
        // etc...
    }
