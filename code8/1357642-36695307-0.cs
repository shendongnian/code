    public async void RunWorkerAsync()
        {
            var result = await RetriveDataAsync();
        }
           
    
     public Task<Object<TItem>> RetriveResultsAsync()
        {
            var tokenSource = new CancellationTokenSource();
            var ct = tokenSource.Token;
    
    
            var source = new TaskCompletionSource<Object<TItem>>();
    
            var task = Task.Run(() =>
            {
                // [B] Here I am in some other thread
                while (!ConditionToStop)
                {
                    if (ct.IsCancellationRequested)
                    {
                        tokenSource.Cancel();
                        ct.ThrowIfCancellationRequested();
                    }
                }
            }, ct).ContinueWith(taskCont =>
            {
               
                if (resultedData != null)
                {
                    source.SetResult(resultedData);
                }
            }, ct);
    
    
            bool taskCompleted = task.Wait(2000, ct);
            if (!taskCompleted)
            {
                tokenSource.Cancel();
            }
    
            return source.Task;
        }
