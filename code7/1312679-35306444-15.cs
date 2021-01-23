    public sealed class ObjectPool<T>
    {
        private readonly Queue<T> __objects;
        public ObjectPool(IEnumerable<T> items)
        {
            __objects = new Queue<T>(items);
        }
        public T Get()
        {
            lock (__objects)
            {
                while (__objects.Count == 0) {
                    Monitor.Wait(__objects);
                }
                return __objects.Dequeue();
            }
        }
        public void Return(T obj)
        {
            lock (__objects)
            {
                __objects.Enqueue(obj);
                Monitor.Pulse(__objects);
            }
        }
    }
