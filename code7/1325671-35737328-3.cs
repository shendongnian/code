    static async Task InvokeAsync(IEnumerable<Func<Task>> taskFactories, int maxDegreeOfParallelism)
    {
        Queue<Func<Task>> queue = new Queue<Func<Task>>(taskFactories);
        if (queue.Count == 0) {
            return;
        }
        List<Task> tasksInFlight = new List<Task>(maxDegreeOfParallelism);
        do
        {
            while (tasksInFlight.Count < maxDegreeOfParallelism && queue.Count != 0)
            {
                Func<Task> taskFactory = queue.Dequeue();
                tasksInFlight.Add(taskFactory());
            }
            Task complete = await Task.WhenAny(tasksInFlight).ConfigureAwait(false);
            await complete.ConfigureAwait(false); // Check result.
            tasksInFlight.Remove(complete);
        }
        while (queue.Count != 0 || tasksInFlight.Count != 0);
    }
