    public async Task RunTasks()
    {
        var tasks = new List<Task>
        {
            DoWork(),
            //and so on with the other 9 similar tasks
        };
        await Task.WhenAll(tasks);
        //Run the other tasks            
    }
