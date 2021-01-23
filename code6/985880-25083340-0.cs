    private async Task LongTaskImpl()
    {
        Debug.WriteLine("TASK THREAD ID: " + Thread.CurrentThread.ManagedThreadId);
        for (int i = 0; i < 10000; i++)
        {
           File.ReadAllLines("abc.txt");
           counter++;
        }
    }    
    static async Task LengthyOperation()
    {
        Console.WriteLine("Executing a lengthy operation...");
        Debug.WriteLine("LENGTHY THREAD ID: " + Thread.CurrentThread.ManagedThreadId);
        var task = LongTaskImpl();
        await task;
    }
