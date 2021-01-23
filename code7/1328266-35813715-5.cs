    public static void Main (string[] args)
    {
        var tasks = new List<Task> ();
        for (int i = 0; i < 10; i++) {
            tasks.Add(getItemAsync(i));
        }
        Task.WaitAll(tasks.ToArray());
    }
