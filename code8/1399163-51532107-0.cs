    public class ObjectPool<TObject>
        {
            private int maxPoolSize;
            private SpinLock poolLock;
            private Dictionary<Type, Stack<TObject>> poolCache;
            private Func<TObject> factory;
    
            public ObjectPool(int poolSize)
            {
                this.maxPoolSize = poolSize;
                this.poolLock = new SpinLock(false);
                this.poolCache = new Dictionary<Type, Stack<TObject>>();
            }
    
            public ObjectPool(int poolSize, Func<TObject> factory) : this(poolSize)
            {
                this.factory = factory;
            }
    
            public T Rent<T>() where T : TObject
                => (T)this.Rent(typeof(T));
    
            public TObject Rent(Type type)
            {
                bool lockTaken = false;
                Stack<TObject> cachedCollection;
                this.poolLock.Enter(ref lockTaken);
    
                try
                {
                    if (!this.poolCache.TryGetValue(type, out cachedCollection))
                    {
                        cachedCollection = new Stack<TObject>();
                        this.poolCache.Add(type, cachedCollection);
                    }
                }
                finally
                {
                    if (lockTaken)
                    {
                        this.poolLock.Exit(false);
                    }
                }
    
                if (cachedCollection.Count > 0)
                {
                    TObject instance = cachedCollection.Pop();
                    if (instance != null)
                        return instance;
                }
    
                // New instances don't need to be prepared for re-use, so we just return it.
                if (this.factory == null)
                {
                    return (TObject)Activator.CreateInstance(type);
                }
                else
                {
                    return this.factory();
                }
            }
    
            public void Return(TObject instanceObject)
            {
                Stack<TObject> cachedCollection = null;
                Type type = typeof(TObject);
    
                bool lockTaken = false;
                this.poolLock.Enter(ref lockTaken);
                try
                {
                    if (!this.poolCache.TryGetValue(type, out cachedCollection))
                    {
                        cachedCollection = new Stack<TObject>();
                        this.poolCache.Add(type, cachedCollection);
                    }
    
                    if (cachedCollection.Count >= this.maxPoolSize)
                    {
                        return;
                    }
    
                    cachedCollection.Push(instanceObject);
                }
                finally
                {
                    if (lockTaken)
                    {
                        this.poolLock.Exit(false);
                    }
                }
            }
        }
