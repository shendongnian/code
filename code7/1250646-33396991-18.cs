    private static void Main()
    {
        Random r = new Random();
        var items = Enumerable.Range(0, 100).Select(x => r.Next(100, 200)).ToList();
        Task t = ParallelQueue(items, DoWork);
        // able to do other things.
        t.Wait();
    }
    private static async Task ParallelQueue<T>(List<T> items, Func<T, Task> func)
    {
        Queue pending = new Queue(items);
        List<Task> working = new List<Task>();
        while (pending.Count + working.Count != 0)
        {
            if (working.Count < 16 && pending.Count != 0)
            {
                var item = pending.Dequeue();
                working.Add(Task.Run(async () => await func((T)item)));
            }
            else
            {
                await Task.WhenAny(working);
                working.RemoveAll(x => x.IsCompleted);
            }
        }
    }
    private static async Task DoWork(int i)
    {
        await Task.Delay(i);
    }
