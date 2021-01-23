    private static void Main()
    {
        Random r = new Random();
        var items = Enumerable.Range(0, 100).Select(x => r.Next(100, 200)).ToList();
        
        ParallelQueue(items, DoWork);
    }
    
    private static void ParallelQueue<T>(List<T> items,Action<T> action)
    {
        Queue pending = new Queue(items);
        List<Task> working = new List<Task>();
        while (pending.Count + working.Count != 0)
        {
            if (pending.Count != 0 && working.Count < 16)  // Maximum tasks
            {
                var item = pending.Dequeue(); // get item from queue
                working.Add(Task.Run(() =>  action((T)item))); // run task
            }
            else
            {
                var any = Task.WhenAny(working); 
                if (any.Result.IsCompleted) working.RemoveAll(x => x.IsCompleted); // remove finished tasks
            }
        }
    }
    private static void DoWork(int i) // do your work here.
    {
        Task.Delay(i).Wait(); // this is just an example
        Console.WriteLine(i); // this is just an example
    }
