    using System;
    using System.Threading;
    
    namespace ADifferentLazy
    {
        /// <summary>
        /// Basically the same as Lazy with LazyThreadSafetyMode of ExecutionAndPublication, BUT exceptions are not cached 
        /// </summary>
        public class LazyWithNoExceptionCaching<T>
        {
            private Func<T> valueFactory;
            private T value = default(T);
            private readonly object lockObject = new object();
            private bool initialized = false;
            private static readonly Func<T> ALREADY_INVOKED_SENTINEL = () => default(T);
    
            public LazyWithNoExceptionCaching(Func<T> valueFactory)
            {
                this.valueFactory = valueFactory;
            }
    
            public bool IsValueCreated
            {
                get { return initialized; }
            }
    
            public T Value
            {
                get
                {
                    //Mimic LazyInitializer.EnsureInitialized()'s double-checked locking, whilst allowing control flow to clear valueFactory on successful initialisation
                    if (Volatile.Read(ref initialized))
                        return value;
    
                    lock (lockObject)
                    {
                        if (Volatile.Read(ref initialized))
                            return value;
    
                        value = valueFactory();
                        Volatile.Write(ref initialized, true);
                    }
                    valueFactory = ALREADY_INVOKED_SENTINEL;
                    return value;
                }
            }
        }
    }
