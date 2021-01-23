    public partial class Service1 : ServiceBase
    {
		YourServiceClass service;
        private Timer serviceTimer;
		
        public Service1()
        {
            InitializeComponent();
            service = new YourServiceClass();
        }
        protected override void OnStart(string[] args)
        {
            TimerCallback timerDelegate = new TimerCallback(service.GetData); // You should add this function to your class. You have an example below
            string time = System.Configuration.ConfigurationSettings.AppSettings["SceduleTime"];	// Gets time from app.config like 12:50
            string[] timeS = time.Split(':');
            DateTime DateIni = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(timeS[0]), Convert.ToInt32(timeS[1]), 0);
            TimeSpan diff = DateTime.Now - DateIni;
            if (diff.TotalSeconds < 0)
                diff = DateIni - DateTime.Now;
            else
                diff = DateIni.AddDays(1) - DateTime.Now;
            // create timer and attach our method delegate to it
            serviceTimer = new Timer(timerDelegate, service, diff, new TimeSpan(1, 0, 0, 0));
        }
        protected override void OnStop()
        {
            serviceTimer.Dispose();
        }
	}
