    private static void Main()
    {
        Random r = new Random();
        var items = Enumerable.Range(0,1000).Select(x=>r.Next(500,1000)).ToList();
        ParallelQueue(items, DoWork);
    }
    private static void ParallelQueue<T>(List<T> items, Func<T,int, Task> func)
    {
        Queue pending = new Queue(items);
        List<Task> working = new List<Task>();
        while (pending.Count + working.Count != 0)
        {
            if (working.Count < 16)
            {
                working.Add(Task.Run(async () => await func((T) pending.Dequeue(), items.Count - pending.Count)));
            }
            else
            {
                Task.WaitAny(working.ToArray());
                working.RemoveAll(x => x.IsCompleted);
            }
        }
    }
    private static async Task DoWork(int i, int index)
    {
        await Task.Delay(i);
        Console.WriteLine(index);
    }
