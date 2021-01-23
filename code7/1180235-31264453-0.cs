    const int BatchSize = 1000;
    var pageAmount = lines / BatchSize;
    var results = Enumerable.Range(1, pageAmount)
                            .AsParallel()
                            .Select(page => DoSomething(page));
    
    public void DoSomething(int page)
    {
        var currentLines = source.Skip(page * BatchSize).Take(BatchSize);
        // do something with the selected lines
    }
    
