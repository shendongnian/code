    using (ServerManager manager = new ServerManager())
    {
        while (true)
        {
            var requests = manager.ApplicationPools
                                    .Where(pool => pool.Name == "FooPool")
                                    .SelectMany(pool => pool.WorkerProcesses)
                                    .SelectMany(wp => wp.GetRequests(10));
            Console.WriteLine(requests.Count());
            Thread.Sleep(100);
        }
    }
