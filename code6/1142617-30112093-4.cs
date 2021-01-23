    public class ProgressReporter
    {
        private readonly SynchronizationContext _syncContext = SynchronizationContext.Current;
        public void ReportProgress(Action progressAction)
        {
            _syncContext.Post(new SendOrPostCallback(unused => progressAction()), null);
        }
    }
