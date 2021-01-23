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
        Queue<InputObject> queue = new Queue<InputObject>(allData);
        if (queue.Count == 0) {
            return table;
        }
        int maxDegreeOfParallelism = Environment.ProcessorCount;
        List<Task<FinalObject>> tasksInFlight = new List<Task<FinalObject>>(maxDegreeOfParallelism);
        do
        {
            while (tasksInFlight.Count < maxDegreeOfParallelism && queue.Count != 0)
            {
                InputObject dataObj = queue.Dequeue();
                Func<Task<FinalObject>> taskFactory = async () =>
                {
                    FinalObject o = await Task.Run(() => Process(dataObj)).ConfigureAwait(false); // Thread pool processing.
                    await Task.Delay(100).ConfigureAwait(false); // Artificial throttling.
                    return o;
                };
                tasksInFlight.Add(taskFactory());
            }
            Task<FinalObject> completedTask = await Task.WhenAny(tasksInFlight).ConfigureAwait(false);
            // Propagate exceptions. In-flight tasks will be abandoned if this throws.
            FinalObject moveObj = await completedTask.ConfigureAwait(false);
            table.Rows.Add(moveObj.x);
            tasksInFlight.Remove(completedTask);
        }
        while (queue.Count != 0 || tasksInFlight.Count != 0);
        return table;
    }
