    public int TestMethod2()
    {
        int i = 1;
        int j = i;
        Task.Run(() => Interlocked.Increment(ref i)).Wait();
        return j;
    }
