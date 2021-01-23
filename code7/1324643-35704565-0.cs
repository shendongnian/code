    public static void MyParallelForEach<TSource, TLocal>(
        IEnumerable<TSource> source, int degreeOfParallelism,
        Func<TLocal> localInit, Func<TSource, TLocal, TLocal> body, Action<TLocal> localFinally)
    {
        var partitionerSource = Partitioner.Create(source).GetDynamicPartitions();
        Action taskAction = () =>
        {
            var localState = localInit();
            foreach (var item in partitionerSource)
            {
                localState = body(item, localState);
            }
            localFinally(localState);
        };
        var tasks = new Task[degreeOfParallelism - 1];
        for (int i = 0; i < degreeOfParallelism - 1; i++)
        {
            tasks[i] = Task.Run(taskAction);
        }
        taskAction();
        Task.WaitAll(tasks);
    }
