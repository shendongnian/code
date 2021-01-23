    private static void Main()
    {
        Task.Factory.StartNew(() => { throw new InvalidOperationException("Erk"); });
        while (true)
        {
            Thread.Sleep(100);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
