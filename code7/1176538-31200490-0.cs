    public class FixedQueue<T> : Queue<T>
    {
        //private readonly ConcurrentQueue<T> _innerQueue;
        private int _capacity;
        public FixedQueue(int capacity) : base()
        {
            _capacity = capacity;
        }
        public void Enqueue(T obj)
        {
            lock(this)
            {
                if (this.Count == _capacity)
                    base.Dequeue();
                base.Enqueue(obj);
            }
        }
        public T Dequeue()
        {
            lock (this)
            {
                return this.Dequeue();
            }
        }
    }
