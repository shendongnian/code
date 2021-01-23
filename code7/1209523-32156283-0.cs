    Random rng = new Random((int)DateTime.UtcNow.Ticks);
    int delay = rng.Next(1500, 15000);
    Task<int> testTask = Task.Run(
        async () =>
        {
            DateTime startTime = DateTime.Now;
            Console.WriteLine("{0} - Starting test task with delay of {1}ms.", DateTime.Now.ToString("h:mm:ss.ffff"), delay);
            await Task.Delay(delay);
            Console.WriteLine("{0} - Test task finished after {1}ms.", DateTime.Now.ToString("h:mm:ss.ffff"), (DateTime.Now - startTime).TotalMilliseconds);
            return delay;
        });
    Task<int>[] tasks = new[] { testTask };
    Task.WaitAll(tasks);
    Console.WriteLine("{0} - Finished waiting.", DateTime.Now.ToString("h:mm:ss.ffff"));
    // make console stay open till user presses enter
    Console.ReadLine();
