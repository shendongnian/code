    private static void CalculateHistogram(uint[] histo, byte[] buffer)
    {
        Array.Sort(buffer); // so the indexes into histo play well with cache.   
        // todo; rewrite to handle edge-cases.
        var firstRange = new[] {0, buffer.Length/2}; // [inclusive, exclusive]
        var secondRange = new[] {buffer.Length/2, buffer.Length};
        // create two tasks for now ;o
        var tasks = new Task[2];
        var taskIdentifier = 0;
        foreach (var range in new[] {firstRange, secondRange})
        {
            var rangeFix = range; // lambda capture ;s
            tasks[taskIdentifier++] = Task.Factory.StartNew(() =>
            {
                for (var i = rangeFix[0]; i < rangeFix[1]; i++)
                    ++histo[i];
            });
        }
        Task.WaitAll(tasks);
    }
