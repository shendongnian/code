    private void InitiateIterativeHits(int batchCount)
    {
        // It's good programming practice to leave your input variables intact so that 
        // they hold correct value throughout the entire execution
        int desiredRuns = batchCount;
        var hitsPerBatch = 5;
        while (desiredRuns-- > 0)
        {
            var thisBatchHits = new Task[hitsPerBatch];
            for (int taskNumber = 1; taskNumber <= hitsPerBatch; taskNumber++)
                thisBatchHits[taskNumber - 1] = Task.Run(HitAPI);
            Task.WaitAll(thisBatchHits);
            Thread.Delay(1000); //To wait for 1 second before starting another batch of 5
        }
    }
