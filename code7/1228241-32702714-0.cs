    TaskCompletionSource<object> tcs = null;
        
    async void Loop()
    {
        for (int i = 0; i < 100; i++)
        {
            tcs = new TaskCompletionSource<object>();
            Update(i);
            await tcs.Task;
        }
    }
    void Update(int i)
    {
        //asynchronous - returns immediately
    }
    void UpdateComplete()//called from another thread
    {
        tcs.TrySetResult(null);
        //unblock further calls to Update();
    }
