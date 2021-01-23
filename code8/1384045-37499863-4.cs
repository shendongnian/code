    static bool bQuit = false;
    static string LastEntry;
    static void Main(string[] args)
    {
        EventWaitHandle ewh = new EventWaitHandle(false, EventResetMode.AutoReset, "TestEvent");
        ThreadPool.QueueUserWorkItem(new WaitCallback(Thread1));
        Console.WriteLine("TestEvent created.");
        while (!bQuit)
        {
            Console.WriteLine("Press 1 to signal TestEvent.\nPress 2 to quit.");
            switch (LastEntry = Console.ReadLine())
            {
                case "1":
                    ewh.Set();
                    break;
                case "2":
                    bQuit = true;
                    break;
            }
        }
        ewh.Dispose();
        Console.WriteLine("Press Enter to finish exiting.");
        Console.ReadLine();
    }
    static void Thread1(object data)
    {
        WaitHandle wh = EventWaitHandle.OpenExisting("TestEvent");
        RegisteredWaitHandle rwh = ThreadPool.RegisterWaitForSingleObject(
            wh, new WaitOrTimerCallback(Thread2), null, Timeout.Infinite, false);
        Console.WriteLine("Thread {0} registered another thread to run when TestEvent is signaled.",
            Thread.CurrentThread.ManagedThreadId);
        while(!bQuit)
        {
            Console.WriteLine("Thread {0} is running.", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
        }
        rwh.Unregister(wh);
        Console.WriteLine("Thread {0} is exiting", Thread.CurrentThread.ManagedThreadId);
    }
    static void Thread2(object data, bool t)
    {
        Console.WriteLine("Thread {0} started", Thread.CurrentThread.ManagedThreadId);
        while(!bQuit && (LastEntry != Thread.CurrentThread.ManagedThreadId.ToString()))
        {
            Console.WriteLine("Thread {0} is running. Enter {0} to end it",
                Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
        }
        Console.WriteLine("Thread {0} is exiting", Thread.CurrentThread.ManagedThreadId);
    }
