    public class TickRate : IDisposable
    {
        private TickRateData tickRateData;
        private readonly IDisposable _subscription;
        public IObservable<double> Stream { get; }
        public TickRate(double intervalInMinutes)
        {
            var stream = Observable.Interval(TimeSpan.FromMinutes(intervalInMinutes))
                                   .Select(_ => tickRateData.tickrate)
                                   .Publish();
            _subscription = stream.Connect();
            Stream = stream;
        }
        public void Dispose()
        {
            _subscription?.Dispose();
        }
    }
