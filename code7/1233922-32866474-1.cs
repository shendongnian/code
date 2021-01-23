    public void ReportGeneratorFiveThreadTest()
    {
        var tasks = new List<Task>();
        for (var i = 0; i < 1; i++)
        {
            var task = Task.Factory.StartNew(() =>
            {
                // No need thread here
                GenerateReport();
            });
            tasks.Add(task);
        }
        try
        {
            ...
        }
        catch (AggregateException e)
        {
            ...
        }
    }
