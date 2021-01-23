    public class ObjectPool<T>
    {
        private Queue<T> _pool = new Queue<T>();
        public T Get(params object[] parameters)
        {
            T obj;
            if (_pool.Count < 0)
                obj = (T)Activator.CreateInstance(typeof(T), parameters);
            else
                obj = _pool.Dequeue();
            return obj;
        }
    }
