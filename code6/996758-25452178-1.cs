    private Task DoAllWork()
    {
        int[] work = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var queue = new FixedParallelismQueue(maxDegreesOfParallelism);
        var tasks = work.Select(n => queue.Enqueue(() => WorkSingleItem(n));
        return TaskEx.WhenAll(tasks);
    }
