    List<BuyerContext> buyerContexts = GetBuyers();
    var results = new List<Result>();
    
    List<Task> tasks = new List<Task>();
    
    //There really is no need for Parallel.ForEach unless you have hundreds of thousands of requests to make.
    //If that's the case, I hope you have a good network interface!
    foreach (var buyerContext in buyerContexts)
    {
        var task = Task.Run(async () =>
        {
            var result = await BidAsync(buyerContext);
            
            if (result != null)
                results.Add(result);
        }
    }
    
    //Block the current thread until all the calls are completed
    Task.WaitAll(tasks);
    
    foreach (var result in results)
    {
      // do some work here that is predicated on the 
      // Parallel.ForEach having completed all of its calls
    }
