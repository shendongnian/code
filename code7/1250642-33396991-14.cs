    private static void Main()
    {
        Random r = new Random();
        var items = Enumerable.Range(0, 100).Select(x => r.Next(100, 200)).ToList();
        
        ParallelQueue(items, DoWork);
    }
    private static void ParallelQueue<T>(List<T> items, Func<T, Task> func)
    {
        Queue pending = new Queue(items);
        List<Task> working = new List<Task>();
        while (pending.Count + working.Count != 0)
        {
            if (working.Count < 16 && pending.Count != 0) 
            {
                var item = pending.Dequeue();
                working.Add(Task.Run(() =>  func((T)item)));
            }
            else
            {
                var any = Task.WhenAny(working);
                if(any.Result.IsCompleted) working.RemoveAll(x => x.IsCompleted);
            }
        }
    }
    private static async Task DoWork(int i)
    {
        await Task.Delay(i);
    }
