    while ((var messages = myQueueClient.ReceiveBatch(1000)) != null)
    {
        Stopwatch sw = Stopqwatch.StartNew();
        // ReceiveBatch() return IEnumerable<>. No need for .ToList().
        foreach (var message in messages)
        {
            ...
        }
        sw.Stop();
        // If processing took less than a second, sleep
        // for the remainder of that second before getting
        // the next batch.
        if (Timespan.FromSeconds(1) > sw.Elapsed)
        {
            Thread.Sleep(Timespans.FromSeconds(1) - sw.Elapsed);
        }
    }
