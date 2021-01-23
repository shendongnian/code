    public Task<List<string>> LoadExample()
    {
        Task<List<string>> task = LoadMyExampleTask();
        return task.ContinueWith(t => t.IsCompleted ? t.Result : default(List<string>));
    }
