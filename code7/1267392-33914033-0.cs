    //MyController.cs
    public ActionResult GetSomething(int id)
    {
        //lots of stuff here
        var processedResponse = _myService.GetAsync(id).Result;
        //or, .Wait, or Task.Run(...), or something similar
        //lots more stuff here
        return new ContentResult(result);
    }
    
    //MyService.cs
    public async Task<ProcessedResponse> GetAsync(int id)
    {
        var client = new HttpClient();
        var pendingResult1 = client.GetAsync(_url+id);
        var pendingResult2 = someAsyncOperation();
        var result3 = someSyncOperation();
        var result1 = await pendingResult;
        var result2 = await pendingResult2;
        return await Process(result1, result2, result3);
    }
