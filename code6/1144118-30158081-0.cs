    public async Task Start()
    {
        foreach(var item in list)
        {
            taskList.Add(Task.Run(() => this.GetThing(item)));
        }
        Task.WaitAll(taskList.ToArray());
    }
