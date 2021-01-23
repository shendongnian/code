    public class UnhandledErrorTrigger : IDisposable
    {
        private readonly TelemetryClient _telemetryClient;
        public UnhandledErrorTrigger(TelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }              
        public void UnHandledException([ErrorTrigger("0:01:00", 1)] TraceFilter filter, TextWriter log)
        {
            foreach (var traceEvent in filter.Events)
            {
                _telemetryClient.TrackException(traceEvent.Exception);
            }
            // log the last detailed errors to the Dashboard
            log.WriteLine(filter.GetDetailedMessage(1));
        }
        public void Dispose()
        {
            _telemetryClient.Flush();
        }
    }
