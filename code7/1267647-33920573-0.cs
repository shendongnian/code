    public static bool KeepRunning;
    ...
    for (int i = 0; i <= Math.Round(cycleCount); i++)
    {
        if (KeepRunning)
        {    
            var Products = Products(batchSize, languageId, storeId).ToList();
            solrCustomWorker.Add(solrProducts);
            solrCustomWorker.Commit();
        }
    }
