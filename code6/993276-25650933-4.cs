    class Program
    {
        static void Main(string[] args)
        {
            ProcessTcpConnections p = new ProcessTcpConnections(Process.GetCurrentProcess().Id);
            Timer timer = new Timer(UpdateStats, p, 0, 100);
            do
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadString("http://www.example.com");
                }
                Console.ReadKey(true); // press any key to download again
            }
            while (true);
        }
        private static void UpdateStats(object state)
        {
            ProcessTcpConnections p = (ProcessTcpConnections)state;
            p.Update();
            Console.WriteLine("DataBytesIn:" + p.DataBytesIn + " DataBytesOut:" + p.DataBytesOut);
        }
    }
    public class ProcessTcpConnections : TcpConnectionGroup
    {
        public ProcessTcpConnections(int processId)
            : base(c => c.ProcessId == processId)
        {
            ProcessId = processId;
        }
        public int ProcessId { get; private set; }
    }
    public class TcpConnectionGroup
    {
        private List<TcpConnectionStats> _states = new List<TcpConnectionStats>();
        private Func<TcpConnection, bool> _groupFunc;
        public TcpConnectionGroup(Func<TcpConnection, bool> groupFunc)
        {
            if (groupFunc == null)
                throw new ArgumentNullException("groupFunc");
            _groupFunc = groupFunc;
        }
        public void Update()
        {
            foreach (var conn in TcpConnection.GetAll().Where(_groupFunc))
            {
                if (!conn.DataStatsEnabled)
                {
                    conn.DataStatsEnabled = true;
                }
                TcpConnectionStats existing = _states.Find(s => s.Equals(conn));
                if (existing == null)
                {
                    existing = new TcpConnectionStats();
                    _states.Add(existing);
                }
                existing.DataBytesIn = conn.DataBytesIn;
                existing.DataBytesOut = conn.DataBytesOut;
                existing.LocalEndPoint = conn.LocalEndPoint;
                existing.RemoteEndPoint = conn.RemoteEndPoint;
                existing.State = conn.State;
                existing.LastUpdateTime = DateTime.Now;
            }
        }
        public ulong DataBytesIn
        {
            get
            {
                ulong count = 0; foreach (var state in _states) count += state.DataBytesIn; return count;
            }
        }
        public ulong DataBytesOut
        {
            get
            {
                ulong count = 0; foreach (var state in _states) count += state.DataBytesOut; return count;
            }
        }
        private class TcpConnectionStats
        {
            public ulong DataBytesIn { get; set; }
            public ulong DataBytesOut { get; set; }
            public IPEndPoint LocalEndPoint { get; set; }
            public IPEndPoint RemoteEndPoint { get; set; }
            public TcpState State { get; set; }
            public DateTime LastUpdateTime { get;  set; }
            public bool Equals(TcpConnection connection)
            {
                return LocalEndPoint.Equals(connection.LocalEndPoint) && RemoteEndPoint.Equals(connection.RemoteEndPoint);
            }
        }
    }
