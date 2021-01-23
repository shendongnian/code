    private readonly SemaphoreSlim _mutex = new SemaphoreSlim(1);
    void Main()
    {
        Task.Run(()=>DelayAndIncrementAsync());
        Task.Run(()=>DelayAndIncrementAsync());
    }
    public   void  DelayAndIncrementAsync()
    {
        if (_mutex.Wait(2000))
        {
            try
            {
                Console.WriteLine(0);
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Console.WriteLine(1);
            }    
            finally
            {
                _mutex.Release();
            }
        } else {
            //oh noes I don't have the mutex
        }
    }
