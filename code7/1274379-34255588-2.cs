    public virtual Data GetData(Credential credential)
    {
        Task<Data> inProgressDataTask = null;
        lock (_gettingDataTaskLock)
        {
            inProgressDataTask = Task.Factory.StartNew(() => GetDataInternal(credential));
            inProgressDataTask.ContinueWith((task) =>
            {
                lock (_gettingDataTaskLock)
                {
                    //inProgressDataTask = null;
                }
            },
            TaskContinuationOptions.ExecuteSynchronously);
        }
        try
        {
            return inProgressDataTask.Result;
        }
        catch (AggregateException ex)
        {
            throw ex.InnerException;
        }
    }
