    public async Task<IHttpActionResult> Get()
    {
        var cts = new CancellationTokenSource();
        var getCatTask = GetCatAsync(cts.Token);
        var user = await GetUserAsync();
    
        if (user == null)
        {
            cts.Cancel();
            return NotFound();
        }     
    
        var cat = await getCatTask;
        return Ok(cat);
    }
