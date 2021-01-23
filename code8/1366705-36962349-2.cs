    public class FixedSizeQueue<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();
        private readonly int _maxLength;
        public FixedSizeQueue(int maxLength)
        {
            _maxLength = maxLength;
        }
        public void AddItem(T item)
        {
            _queue.Enqueue(item);
            while(_queue.Count > _maxLength)
            {
                _queue.Dequeue();
            }
        }
        public IEnumerable<T> Items()
        {
            return _queue.ToArray();
        }
    }
