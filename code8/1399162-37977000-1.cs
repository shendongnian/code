    public class ObjectPool<T>
    {
        private Queue<T> _pool = new Queue<T>();
        private const int _maxObjects = 100;  // Set this to whatever
        public T Get(params object[] parameters)
        {
            T obj;
            if (_pool.Count < 1)
                obj = (T)Activator.CreateInstance(typeof(T), parameters);
            else
                obj = _pool.Dequeue();
            return obj;
        }
        public void Put(T obj)
        {
            if (_pool.Count < _maxObjects)
                _pool.Enqueue(obj);
        }
    }
