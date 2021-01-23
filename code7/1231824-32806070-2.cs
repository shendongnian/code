    public sealed class BackgroundTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            ...
            AppSynchronization appSynchronization = new AppSynchronization();
            BackgroundTaskDeferral  deferral = taskInstance.GetDeferral();
            // Make sure that the main app is not started. If it is started then wait until the main app gets out of the way. 
            // It he main app is running this will wait indefinitely.
            // Use backgroundAgentCancellationToken to cancel the actions of the background agent when the main app advertises its intention to start.
            CancellationToken backgroundAgentCancellationToken = await appSynchronization.ActivateBackgroundAgent();
            await DoBackgroundAgentWork(backgroundAgentCancellationToken)
            // Advertise the fact that the background agent is out.
            // DeactivateBackgroundAgent will make sure that the synchronization mechanism advertised the fact that the background agent is out.
            // DeactivateBackgroundAgent may have to be declared async in case the synchronization mechanism uses async code to do what is needed.
            await appSynchronization.DeactivateBackgroundAgent();
            deferral.Complete();
        }
