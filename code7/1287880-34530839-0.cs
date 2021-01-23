    private static object syncRoot = new object();
    private static object value = null;
    public static object Value
    {
        get
        {
            if (value == null)
            {
                lock (syncRoot)
                {
                    if (value == null)
                    {
                        // Only one concurrent thread will attempt to create the underlying value.
                        value = GetTheValueFromSomewhere();
                    }
                }
            }
            return value;
        }
    }
