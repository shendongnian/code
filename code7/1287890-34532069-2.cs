    private static int waiters = 0;
    private static volatile Lazy<object> lazy = new Lazy<object>(GetValueFromSomewhere);
    public static object Value
    {
        get
        {
            Lazy<object> currLazy = lazy;
            if (currLazy.IsValueCreated)
                return currLazy.Value;
            Interlocked.Increment(ref waiters);
            try
            {
                return lazy.Value;
                // just leave "waiters" at whatever it is... no harm in it.
            }
            catch
            {
                if (Interlocked.Decrement(ref waiters) == 0)
                    lazy = new Lazy<object>(GetValueFromSomewhere);
                throw;
            }
        }
    }
