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
            // Completion handler: these will be executed one at a time, and can safely mutate shared state.
            moveObj => table.Rows.Add(moveObj.x)
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
