        public static bool IsConnected { get; protected set; }
        protected readonly static object _sync = new object();
        protected static Task NetworkTask;
        
        public static void Start(int period = 1000)
        {
            NetworkTask = Task.Run(() =>
                {
                    lock (_sync)
                    {
                        IsConnected = MyNetworkManager.IsConnected();
                        System.Threading.Thread.Sleep(period);
                    }
                });
        }
