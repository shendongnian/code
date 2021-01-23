    private static ConcurrentQueue<Task> Tasks { get; } = new ConcurrentQueue<Task>();
    public async static Task RunAlone(this Task task)
    {
        Tasks.Enqueue(task);
        do
        {
            var nextTask = Tasks.First();
            if (nextTask == task)
            {
                nextTask.Start();
                await nextTask;
                Task deletingTask;
                Tasks.TryDequeue(out deletingTask);
                break;
            }
            else
            {
                nextTask.Wait();
            }
        } while (Tasks.Any());
    }
    public async static Task<TResult> RunAlone<TResult>(this Task<TResult> task)
    {
        TResult result = default(TResult);
        Tasks.Enqueue(task);
        do
        {
            var nextTask = Tasks.First();
            if (nextTask == task)
            {
                nextTask.Start();
                result = await (Task<TResult>)nextTask;
                Task deletingTask;
                Tasks.TryDequeue(out deletingTask);
                break;
            }
            else
            {
                nextTask.Wait();
            }
        } while (Tasks.Any());
        return result;
    }
