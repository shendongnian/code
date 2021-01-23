    public class Timer : IRegisteredObject
    {
        private Timer _timer;
        public static void Start()
        {
            HostingEnvironment.RegisterObject(new Timer());
        }
        public Timer()
        {
            StartTimer();
        }
        private void StartTimer()
        {
            _timer = new Timer(BroadcastUptimeToClients, null, TimeSpan.FromSeconds(0), TimeSpan.FromMilliseconds(100));     
        }
        private void BroadcastUptimeToClients(object state)
        {
            //some action
        }
        public void Stop(bool immediate)
        {
            //throw new System.NotImplementedException();
        }
    }
