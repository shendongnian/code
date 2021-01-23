    struct InputObject
    {
        public int x;
    }
    struct FinalObject
    {
        public int x;
    }
    FinalObject Process(InputObject o)
    {
        // Simulate synchronous work.
        Thread.Sleep(100);
        return new FinalObject { x = o.x };
    }
    async Task<DataTable> ProcessAllAsync(IEnumerable<InputObject> allData)
    {
        DataTable table = CreateTable();
        int maxDegreeOfParallelism = Environment.ProcessorCount;
        await ParallelForEachAsync(
            allData,
            maxDegreeOfParallelism,
            // Loop body: these Tasks will run in parallel, up to {maxDegreeOfParallelism} at any given time.
            async dataObj =>
            {
                FinalObject o = await Task.Run(() => Process(dataObj)).ConfigureAwait(false); // Thread pool processing.
                await Task.Delay(100).ConfigureAwait(false); // Artificial throttling.
                return o;
            },
            // Completion handler: these Tasks will run one at a time, and can safely mutate shared state.
            async completedProcessTask =>
            {
                FinalObject o = await completedProcessTask.ConfigureAwait(false);
                table.Rows.Add(o.x);
            }
        );
        return table;
    }
    async Task ParallelForEachAsync<T, TTask>(IEnumerable<T> input,
                                              int maxDegreeOfParallelism,
                                              Func<T, TTask> body,
                                              Func<TTask, Task> onCompleted)
        where TTask : Task
    {
        Queue<T> queue = new Queue<T>(input);
        if (queue.Count == 0) {
            return;
        }
        List<TTask> tasksInFlight = new List<TTask>(maxDegreeOfParallelism);
        do
        {
            while (tasksInFlight.Count < maxDegreeOfParallelism && queue.Count != 0)
            {
                T item = queue.Dequeue();
                tasksInFlight.Add(body(item));
            }
            TTask completedTask = (TTask)await Task.WhenAny(tasksInFlight).ConfigureAwait(false);
            await onCompleted(completedTask).ConfigureAwait(false);
            tasksInFlight.Remove(completedTask);
        }
        while (queue.Count != 0 || tasksInFlight.Count != 0);
    }
