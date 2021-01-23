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
                        // And if `GetTheValueFromSomewhere` throws an exception, then the value field
                        // will not be assigned to anything and later access
                        // to the Value property will retry. As far as the exception
                        // is concerned it will obviously be propagated
                        // to the consumer of the Value getter
                        value = GetTheValueFromSomewhere();
                    }
                }
            }
            return value;
        }
    }
