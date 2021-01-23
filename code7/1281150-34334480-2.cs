    static async Task Test()
    {
        Task t1 = StringAsync();
        Task t2 = IntAsync();
        Task t3 = ListAsync();
        await Task.WhenAll(t1, t2, t3); 
        // your continuation logic here
    }
