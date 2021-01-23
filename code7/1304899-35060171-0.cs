    class Work
    {
        public static void WorkMethod(object stateInfo)
        {
            Console.WriteLine("Work starting.");
            ((ManualResetEvent)stateInfo).WaitOne();
            Console.WriteLine("Work ending.");
        }
    }
        // Example:
        ManualResetEvent manualEvent = new ManualResetEvent(false);
        Thread newThread = new Thread(Work.WorkMethod);
        newThread.Start(manualEvent);
        // This will terminate all threads that are waiting on this handle:
        manualEvent.Set();
        
