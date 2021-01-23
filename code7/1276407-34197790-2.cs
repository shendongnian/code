    public Task<List<string>> LoadExample()
    {
        Task<List<string>> task = LoadMyExampleTask();
        return task.ContinueWith(t => 
                t.IsFaulted || t.IsCanceled ? default(List<string>) : t.Result);
    }
