    // in async button click event
    button.Enabled = false;
    var dt = await ReadData(int id);
    button.Enabled = true;
    ... // do something with dt
    public async Task<DataTable> ReadData(int id)
    { 
         ...
         var job1 = adapter.AsyncFill(dt1);
         var job2 = adapter.Fill(dt2); 
         // wait for all of them to finish
         Task.WaitAll(new[] {job1, job2});
         ...
         return Task.FromResult(resultDT); // dump approach
    }
