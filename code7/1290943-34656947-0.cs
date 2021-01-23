    try
    {
        List<Task<File[]>> stage1Tasks = new List<Task<File[]>>();
        // ==== stage 1 ======
        for (int i = 0; i < 10; i++)
        {
            string directoryName = directories[i];
            Task<File[]> t = Task.Run(() =>
            {
                return FindFiles(directoryName);
            },
                token);
            stage1Tasks.Add(t);
        }
        File[][] files = await Task.WhenAll(stage1Tasks).ConfigureAwait(false);
        // Flatten files.
        File[] _fileResults = files.SelectMany(x => x).ToArray();
        // ==== stage 2 ====
        Task<File[]> sortFilesTask = Task.Run(() =>
        {
            if (_fileResults.Count > 1)
            {
                // sort the files and remove any duplicates
                return _fileResults.Reverse().ToArray();
            }
        },
            token);
        File[] _sortedFileResults = await sortFilesTask.ConfigureAwait(false);
        // ==== stage 3 ====
        Task<SomeResult[]> tt = Task.Run(() =>
        {
            SomeResult[] results = new SomeResult[_sortedFileResults.Length];
            Parallel.ForEach(_sortedFileResults,
                new ParallelOptions {
                    MaxDegreeOfParallelism = Environment.ProcessorCount,
                    CancellationToken = token,
                    TaskScheduler = _taskScheduler
                },
                (i, loopstate) =>
                {
                    // 1. open file
                    // 2. read file
                    // 3. read file line by line
                    results[i] = new SomeResult( /* here goes your results for each file */);
                });
            return results;
        },
            token);
        SomeResult[] theResults = await tt.ConfigureAwait(false);
        // == stage 4 === 
        // 1. aggregate the file results into one giant result set
        // 2. display the giant result set in human readable format
        // ....
    }
    catch (TaskCanceledException)
    {
        // some task has been cancelled...
    }
