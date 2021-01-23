    public partial class UssPwdSyncService : ServiceBase
    {
        private Timer timer1 = null; 
        public UssPwdSyncService()
        {
            InitializeComponent();
            this.timer1 = new Timer();
            this.timer1.Interval = 20000;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_tick);
    
            LogHandling.WriteErrorLogs("Service has started! LOg!");
        }
        protected override void OnStart(string[] args)
        {
            this.timer1.Start();
        }
        private void timer1_tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                ConfigurationManager.RefreshSection("connectionStrings");
                foreach (ConnectionStringSettings cStr in ConfigurationManager.ConnectionStrings)
                {
                    string name = cStr.Name;
                    string connString = cStr.ConnectionString;
                    string provider = cStr.ProviderName;
    
                    LogHandling.WriteErrorLogs(name + " " + connString + " " + provider);
                }
                LogHandling.WriteErrorLogs("This does something!");
            }
            catch (Exception ex)
            {
                LogHandling.WriteErrorLogs(ex);
            }
        }
        protected override void OnStop()
        {
            this.timer1.Stop();
            LogHandling.WriteErrorLogs("Service has stoped!");
        }
    }
