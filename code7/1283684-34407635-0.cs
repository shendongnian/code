    public class QueueFactory<T>
    {
        static Type queueType = typeof(T).IsValueType ?
             typeof(StructQueue<>).MakeGenericType(typeof(T)) : typeof(RefQueue<>).MakeGenericType(typeof(T));
        public static IQueue<T> CreateQueue()
        {
            return (IQueue<T>)Activator.CreateInstance(queueType);
        }
    }
