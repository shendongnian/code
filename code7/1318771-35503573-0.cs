    Parallel.For(0, 10, i => DoSomething(i));
    
    ...
    
    private static int parallelCounter = 0;
    private static object counterLockObject = new Object();
    void DoSomething(int par)
    {
        int myCounter;
        lock(counterLockObject)
        {
            myCounter = parallelCounter++;
        }
        try
        {
            // you probably need something that takes more time to
            // see anything executing in parallel
            Console.WriteLine($"Test: {par}", myCounter);
        }
        finally
        {
            lock(counterLockObject)
            {
                parallelCounter--;
            }        
        }
    }
