    async Task ParallelForEachAsync<TInput, TResult>(IEnumerable<TInput> input,
                                                     int maxDegreeOfParallelism,
                                                     Func<TInput, Task<TResult>> body,
                                                     Action<TResult> onCompleted)
    {
        Queue<TInput> queue = new Queue<TInput>(input);
        if (queue.Count == 0) {
            return;
        }
        List<Task<TResult>> tasksInFlight = new List<Task<TResult>>(maxDegreeOfParallelism);
        do
        {
            while (tasksInFlight.Count < maxDegreeOfParallelism && queue.Count != 0)
            {
                TInput item = queue.Dequeue();
                Task<TResult> task = body(item);
                tasksInFlight.Add(task);
            }
            Task<TResult> completedTask = await Task.WhenAny(tasksInFlight).ConfigureAwait(false);
            tasksInFlight.Remove(completedTask);
            TResult result = completedTask.GetAwaiter().GetResult(); // We know the task has completed. No need for await.
            onCompleted(result);
        }
        while (queue.Count != 0 || tasksInFlight.Count != 0);
    }
