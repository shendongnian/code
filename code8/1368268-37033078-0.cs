    public void DoAsyncWork()
    {
        Task<HttpResponseMessage> task = Task.Run(() => DoWork());
        CallbackWithAsyncResult(task);
    }
    private async void CallbackWithAsyncResult(Task<HttpResponseMessage> asyncPrerequisiteCheck)
    {
        try
        {
            await asyncPrerequisiteCheck;
        }
        finally
        {
            form.Callback(asyncPrerequisiteCheck);
        }
    }
