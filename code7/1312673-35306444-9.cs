    public sealed class ObjectPool<T>
    {
        private readonly ConcurrentQueue<T> __objects = new ConcurrentQueue<T>();
        private readonly Func<T> __factory;
        public ObjectPool(Func<T> factory)
        {
            __factory = factory;
        }
        public T Get()
        {
            T obj;
            return __objects.TryDequeue(out obj) ? obj : __factory();
        }
        public void Return(T obj)
        {
            __objects.Enqueue(obj);
        }
    }
