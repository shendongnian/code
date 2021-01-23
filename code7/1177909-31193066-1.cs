    void MethodA()
    {
        lock (Lock1)
        {
            CommonMethod();
        }
    }
    void MethodB()
    {
        lock (Lock3)
        {
            CommonMethod();
        }
    }
    void CommonMethod()
    {
        lock (Lock2)
        {
        }
    }
    void MethodC()
    {
        lock (Lock1)
        {
            lock (Lock2)
            {
                lock (Lock3)
                {
                }
            }
        }
    }
