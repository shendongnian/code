    static async Task TaskWhichUsedToWorkButNotAnymore()
    {
        List<Task> tasks = new List<Task>();
        Task task = FooAsync();
        tasks.Add(task);
        Task<Task> continuationTask = task.ContinueWith(async t =>
        {
            List<Task> childTasks = new List<Task>();
            for (int i = 1; i <= 5; i++)
            {
                var ct = FooAsync();
                childTasks.Add(ct);
            }
            Task wa = Task.WhenAll(childTasks.ToArray());
            await wa.ConfigureAwait(continueOnCapturedContext: false);
        }, TaskContinuationOptions.OnlyOnRanToCompletion);
        tasks.Add(continuationTask);
        // Let's Unwrap the async/await way.
        // Pay attention to the return type.
        // The await completes immediately and
        // produces another task, which represents
        // the completion of the task started inside
        // (and returned by) the ContinueWith delegate.
        Task unwrappedTask = await continuationTask;
        // Boom! This method now has the
        // same behaviour as the other one.
        tasks.Add(unwrappedTask);
        await Task.WhenAll(tasks.ToArray());
    }
