    SemaphoreSlim sem = new SemaphoreSlim(4,4);
    foreach (var service in RunData.Demand)
    {
        await sem.WaitAsync();
        Task t = Task.Run(async () => 
        {
            var availabilityResponse = await client.QueryAvailability(service));    
            // do your other stuff here with the result of QueryAvailability
        }
        t.ContinueWith(sem.Release());
    }
