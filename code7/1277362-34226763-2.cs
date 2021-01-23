    public class DataService : IDataService
    {
        private const int UpdateInterval = 1000; //1000ms = 1s
        private readonly DataCredentials _credentials;
        private Timer _dataUpdateTimer;
    
        public DataService(DataCredentials credentials)
        {
            _credentials = credentials;
            _dataUpdateTimer = new Timer(UpdateInterval);
    
            _dataUpdateTimer.Elapsed += DataUpdateTimer_Elapsed;
            _dataUpdateTimer.Start();
        }
    
        private void DataUpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Call your code in here
            var data = GetData(_credentials);
            //.....
            //Reset your timer
            _dataUpdateTimer.Stop();
            _dataUpdateTimer.Start();
        }
        public Data GetData(DataCredentials dataCredentials) {...}
    }
