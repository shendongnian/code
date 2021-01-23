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
            Task completedTask = await Task.WhenAny(tasksInFlight).ConfigureAwait(false);
            // Propagate exceptions. In-flight-tasks will be abandoned if this throws.
            await completedTask.ConfigureAwait(false);
            tasksInFlight.Remove(completedTask);
        }
        while (queue.Count != 0 || tasksInFlight.Count != 0);
    }
