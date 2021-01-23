    public async Task RunTasks()
    {
        await Task.WhenAll(new [] 
        {
            DoWork(),
            //...
        });
        //Run the other tasks
    }
