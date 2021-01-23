    public sealed class Notification : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            Debug.WriteLine("Background starting...");
            Debug.WriteLine("Background completed!");
        }
    }
