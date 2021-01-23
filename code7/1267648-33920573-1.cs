    public void SomeMethod(Func<bool> keepRunning)
    {
        for (int i = 0; i <= Math.Round(cycleCount); i++)
        {
            if (keepRunning())
            {    
                var Products = Products(batchSize, languageId, storeId).ToList();
                solrCustomWorker.Add(solrProducts);
                solrCustomWorker.Commit();
            }
        }
    }
