    private static object syncRoot = new object();
    private static Lazy<object> lazy = new Lazy<object>(GetTheValueFromSomewhere);
    public static object Value
    {
        get
        {
            try
            {
                return lazy.Value;
            }
            catch
            {
                lock (syncRoot)
                {
                    // We recreate the lazy field so that subsequent readers
                    // don't just get a cached exception but rather attempt
                    // to call the GetTheValueFromSomewhere() expensive method
                    // in order to calculate the value again
                    lazy = new Lazy<object>(GetTheValueFromSomewhere);
                    // Rethrow the exception so that all blocked reader threads
                    // will get this exact same exception thrown.
                    throw;
                }
            }
        }
    }
