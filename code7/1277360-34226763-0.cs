    public class DataService : IDataService
    {
        private Timer _dataUpdateTimer;
        private readonly TimeSpan _updateInterval = TimeSpan.FromMinutes(1);
    
        public DataService()
        {
            _dataUpdateTimer = new Timer(GetData(?),
                                         null,
                                         TimeSpan.Zero,
                                         _updateInterval);
    
            _dataUpdateTimer.Elapsed += DataUpdateTimer_Elapsed;
            _dataUpdateTimer.Start();
        }
    
        private void DataUpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Call your code in here
            //Reset your timer
            _dataUpdateTimer.Stop();
            _dataUpdateTimer.Start();
        }
        public Data GetData(DataCredentials dataCredentials) {...}
    }
