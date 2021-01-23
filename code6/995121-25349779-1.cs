        int nrWorkers = 3;
        int nrUrls = 10;
        BlockingCollection<Uri> taskQ = new BlockingCollection<Uri>();
        foreach (int i in Enumerable.Range(0, nrWorkers))
        {
            Task.Run(() => StartScraping(i, taskQ.GetConsumingEnumerable()));
        }
        foreach (int i in Enumerable.Range(0, nrUrls))
        {
            taskQ.Add(new Uri(String.Format("http://Url{0}", i)));
        }
        taskQ.CompleteAdding();
