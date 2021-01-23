    private async Task Run()
    {
        var tasks =
            Enumerable.Range(0, ConfigReader.ThreadCount)
            .Select(i => Task.Run(() => new XyzServices().ProcessXyz()));
        await Task.WhenAll(tasks); 
    }
    
