    using System.Collections.Concurrent;
    public LockedObject<T>
    {
        public readonly T data;
        public readonly int id;
        private readonly object obj = new object();
        LockedObject(int id, T data)
        {
            this.id = id;
            this.data = data;
        }
        
        //Usually, if you have Action related to some data,
        //it is better to receive
        //that data as parameter
        public void InvokeAction(Action<T> action)
        {
            lock(obj)
            {
                action(data);
            }
        }
    }
    //Now it is a concurrently safe object applying some action
    //concurrently on given data, no matter how it is stored.
    //But still, this is the best idea:
    
    ConcurrentDictionary<int, LockedObject<T>> dict =
    new ConcurrentDictionary<int, LockedObject<T>>();
    
    //You can insert, read, remove all object's concurrently.
