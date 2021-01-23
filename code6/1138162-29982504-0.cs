    public void Run1<T>()
    {
        // ...
        if (typeof(IEnumerable).IsAssignableFrom(typeof(T))
        {
            Run2Impl<T>();
        }
        // ...
    }
    
    public void Run2<T>() where T : IEnumerable
    {
        Run2Impl<T>();
    }
    private void Run2Impl<T>()
    {
        // Need to cast any values of T to IEnumerable here
    }
