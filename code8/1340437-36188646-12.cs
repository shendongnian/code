    async Task<DataTable> ProcessAllAsync(IEnumerable<InputObject> allData)
    {
        DataTable table = CreateTable();
        int maxDegreeOfParallelism = Environment.ProcessorCount;
        await ParallelForEachAsync(
            allData,
            maxDegreeOfParallelism,
            // Loop body: these Tasks will run in parallel, up
            // to {maxDegreeOfParallelism} at any given time.
            async dataObj =>
            {
                // Thread pool processing.
                FinalObject o = await Task.Run(() => Process(dataObj)).ConfigureAwait(false);
                // Artificial throttling.
                await Task.Delay(100).ConfigureAwait(false);
                return o;
            },
            // Completion handler: these Tasks will run one
            // at a time, and can safely mutate shared state.
            async completedProcessTask =>
            {
                FinalObject o = await completedProcessTask.ConfigureAwait(false);
                table.Rows.Add(o.x);
            }
        );
        return table;
    }
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
