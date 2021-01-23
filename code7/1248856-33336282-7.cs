        private static object _lockObject;
    
    // ...
    
            // Do not allow concurrency, blocking
            for (int i = 0; i < 10000000; i++)
            {
                lock (_lockObject)
                {
                    // original code
                }
            }
            // Do not allow concurrency, non-blocking
            for (int i = 0; i < 10000000; i++)
            {
                bool lockTaken = false;
                try
                {
                    Monitor.TryEnter(_lockObject, ref lockTaken);
                    if (lockTaken)
                    {
                        // original code
                    }
                }
                finally
                {
                    if (lockTaken) Monitor.Exit(_lockObject);
                }
            }
