    async Task MainAsync()
    {
        var task1 = FooAsync();
        var task2 = BarAsync();
        await Task.WhenAll(task1, task2);
        
        var result = Combine(task1.Result, task2.Result);
    }
    
    async Task<Result> FooAsync()
    {
        var records = await DB.ReadAsync("..");
        //Do A lot
        return Process(records);  
    }
    
    async Task<Result> BarAsync()
    {
        var records = await DB.ReadAsync(".....");
        //Do A lot
        return Process(records);
    }
