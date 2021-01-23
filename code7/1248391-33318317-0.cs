    namespace sendMailService
    {
        public partial class Service1 : ServiceBase
        {
            private System.Threading.Timer IntervalTimer;
            public Service1()
            {
                InitializeComponent();
            }
    
            protected override void OnStart(string[] args)
            {
                TimeSpan tsInterval = new TimeSpan(0, 0, Properties.Settings.Default.PollingFreqInSec);
                IntervalTimer = new System.Threading.Timer(
                    new System.Threading.TimerCallback(IntervalTimer_Elapsed)
                    , null, tsInterval, tsInterval);
            }
    
            protected override void OnStop()
            {
                IntervalTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                IntervalTimer.Dispose();
                IntervalTimer = null;
            }
    
            private void IntervalTimer_Elapsed(object state)
            {   
                 // Do the thing that needs doing every few minutes...
                 sendMail();
            }
        }
    }
