    public int i = 1;
    
    public int TestMethod1()
    {
        int j = i;
        Task.Run(() => Interlocked.Increment(ref i)).Wait();
        return j;
    }
