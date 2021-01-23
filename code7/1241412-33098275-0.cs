    List<Task> tasks = new List<Task>();
    for (int i = 0; i < 21000; i++)
    {
        tasks.Add(Task.Factory.StartNew(() =>
        {
            MultithreadedMethod();
        }));
    }
    Task.WaitAll(tasks.ToArray());
