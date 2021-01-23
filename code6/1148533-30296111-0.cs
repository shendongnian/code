    using (var context = new MyDbContext())
    {
        IEnumerable<ProcessStartInfo> processInfos = GetProcessInfos(context, args[0]);
        foreach (ProcessStartInfo processInfo in processInfos)
        {
            using (var process = Process.Start(processInfo))
            {
                // Blocks until the process ends
                process.WaitForExit();
            }
            // When the `using` block is left, `process.Dispose()` is called.
        }
    }
