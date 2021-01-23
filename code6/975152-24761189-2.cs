    // create a global instance of ThreadAffinityTaskScheduler - per web app
    public static class GlobalState 
    {
        public static ThreadAffinityTaskScheduler TaScheduler { get; private set; }
    
        public static GlobalState() 
        {
            GlobalState.TaScheduler = new ThreadAffinityTaskScheduler(
                numberOfThreads: 10,
                staThreads: true, 
                waitHelper: WaitHelpers.WaitWithMessageLoop);
        }
    }
    // ... inside Page_Load
    GlobalState.TaScheduler.Run(() => 
    {
        var control = (dynamic)Interaction.GetObject("script:" + controlFilename, null);
        logger("About to call Go");
        control.Go(new DataProvider(logger));
        logger("Completed");
    }, CancellationToken.None).Wait();
