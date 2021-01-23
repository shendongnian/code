    public class SignalRTimer : IRegisteredObject
    {
        private readonly IHubContext _uptimeHub;
        private Timer _timer;
        public static void Start()
        {
            HostingEnvironment.RegisterObject(new SignalRTimer());
        }
        public SignalRTimer()
        {
            _uptimeHub = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
 
            StartTimer();
        }
        private void StartTimer()
        {
            _timer = new Timer(BroadcastUptimeToClients, null, TimeSpan.FromSeconds(0), TimeSpan.FromMilliseconds(100));     
        }
        private void BroadcastUptimeToClients(object state)
        {
            _uptimeHub.Clients.All.broadcastMessage("some message");
        }
        public void Stop(bool immediate)
        {
            //throw new System.NotImplementedException();
        }
    }
