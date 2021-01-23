    public MyRepository()
    {
        Task.Run(async () => { await LoadDataAsync(url); });
        System.Threading.Thread.Sleep(10000); //will sleep for 10 seconds
    }
