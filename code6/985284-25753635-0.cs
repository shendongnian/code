    private static int sharedVariable;
    private static object _syncronizationObject = new Object();
    public void MethodThatUsesStaticVariable(int newValue)
    {
        // This lock prevents concurrency problems, and this is what solved the issue for me.
        lock(_syncronizationObject)
        {
            sharedVariable = newValue;
        }
    }
