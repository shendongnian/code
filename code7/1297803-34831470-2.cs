    public class ForecastApiAsyncTimer : IDisposable
    {
        private ForecastApi _api;
        private Timer _timer;
        public ForecastApiAsyncTimer(double interval, ForecastApi forecastApi)
        {
            if (forecastApi == null)
                throw new ArgumentNullException("forecastApi");
            _api = forecastApi;
            _timer = new Timer(interval);
            _timer.Elapsed += _timer_Elapsed;
        }
        public void Start()
        {
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }
        protected async virtual Task<int> TimerElapsedTask()
        {
            var forecast = await _api.GetWeatherDataAsync(40.7505045d, -73.9934387d);
            int tempC = (int)(5.0 / 9.0 * (forecast.Currently.Temperature - 32));
            return tempC;
        }
        async void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int result = await TimerElapsedTask();
            // do something with result.
        }
        ~ForecastApiAsyncTimer()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || _timer == null)
                return;
            _timer.Dispose();
            _timer = null;
        }
    }
