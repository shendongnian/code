    private static void Main()
    {
        for (int i = 0; i < Environment.ProcessorCount; i++)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));
        }
        Console.ReadLine();
    }
    static void ThreadProc(Object stateInfo)
    {
        while (true)
        {
           // do something
        }
    }
