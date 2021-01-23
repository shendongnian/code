    private readonly object lock1 = new object();
    private readonly object lock2 = new object();
    public void Method1()
    {
        lock(lock1)
        {
            Thread.Sleep(1000);
            lock(lock2)
            {
            }
        }
    }
    public void Method2()
    {
        lock(lock2)
        {
            Thread.Sleep(1000);
            lock(lock1)
            {
            }
        }
    }
