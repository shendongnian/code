    List<string> source = Enumerable.Range(0, 20000).Select(i => i.ToString()).ToList();
    DataTable endResult = CreateEmptyTable();
    object lck = new object();
    
    Parallel.For(
        0, source.Count,
        () => CreateEmptyTable(), // method to initialize the thread-local table
        (i, state, threadLocalTable) => // method invoked by the loop on each iteration
        {
            DataRow dr = threadLocalTable.NewRow();
    
            // running in parallel can only be beneficial if you do some CPU-heavy conversion in here
            // rather than simple assignment as below
            dr[0] = source[i];
    
            threadLocalTable.Rows.Add(dr);
            return threadLocalTable;
        },
    
        // Method to be executed when each partition has completed. 
        localTable =>
        {
            // lock to ensure that the result table is not screwed by merging from multiple threads simultaneously
            lock (lck)
            {
                endResult.Merge(localTable);
            }
        }
    );
