    public sealed class StartupTask : IBackgroundTask
    {
        private BackgroundTaskDeferral _defferal;
        internal static TelemetryClient TelemetryClient = new TelemetryClient();
        public StartupTask()
        {
            TelemetryClient.InstrumentationKey = "1234567-1111-1234-1234-1234567890ab";
        }
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var cancellationTokenSource = new System.Threading.CancellationTokenSource();
            taskInstance.Canceled += TaskInstance_Canceled;
            _defferal = taskInstance.GetDeferral();
            ... [insert your code]...
        }
    }
