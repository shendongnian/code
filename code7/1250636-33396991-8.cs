    private static void Main()
    {
        var items = new List<int> {3000, 50, 2000, 500, 200, 500, 500, 5000, 500, 500};
        ParallelQueue(items, DoWork); // list of items. DoWork does something with each element of this list.
    }
    private static void ParallelQueue<T>(List<T> items, Func<T,Task> func)
    {
        Queue pending = new Queue(items);
        List<Task> working = new List<Task>();
        while (pending.Count + working.Count != 0)
        {
            if (working.Count < 4) // maximum number of tasks. (working.Count < Environment.ProcessorCount)
            {
                working.Add(Task.Run(async () => await func((T)pending.Dequeue()))); // dequeue and add to working list.
            }
            else
            {
                int index = Task.WaitAny(working.ToArray()); // wait for one task to finish
                
                working.RemoveAll(x => x.IsCompleted); // remove finished task
            }
        }
    }
    private static async Task DoWork(int i) // do your work here.
    {
        await Task.Delay(i); // this is just an example.
        Console.WriteLine(i); // this is just an example.
    }
