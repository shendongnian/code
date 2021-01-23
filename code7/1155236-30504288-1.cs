    private static readonly TaskScheduler singleThreadedScheduler = new SingleThreadedTaskScheduler();
    private static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            int index = i;
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);//Simulate some work
                Console.WriteLine("Task id {0} Executed in Thread Id {1}", index, Thread.CurrentThread.ManagedThreadId);
            }, CancellationToken.None, TaskCreationOptions.None, singleThreadedScheduler);
        }
    }
