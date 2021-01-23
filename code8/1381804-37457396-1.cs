    public async void Run(IBackgroundTaskInstance taskInstance)
    {
        BackgroundTaskDeferral deferral = taskInstance.GetDeferral();
        // perform your async task and then call deferral  complete
        await Test();
        deferral.Complete();
    }
    private static async Task Test()
    {
        //TODO with an await
    }
