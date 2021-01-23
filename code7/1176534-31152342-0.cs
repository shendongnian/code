    public class LimitedQueue<T>
    {
        private readonly Queue<T> _queue;
        private readonly int _limit;
        public LimitedQueue(int limit)
        {
            _queue = new Queue<T>();
            _limit = limit;
        }
        public void Enqueue(T item)
        {
            if (_queue.Count == _limit) _queue.Dequeue();
            _queue.Enqueue(item);
        }
        public T Dequeue()
        {
            return _queue.Dequeue();
        }
        public T Peek()
        {
            return _queue.Peek();
        }
        public T[] GetAll()
        {
            return _queue.ToArray();
        }
    }
