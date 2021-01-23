    public partial class Service1 : ServiceBase
    {
        private Timer Schedular;
        public Service1()
        {
            InitializeComponent();
            Schedular = new Timer(new TimerCallback(SchedularCallback), nulll, Timeout.Infinite, Timeout.Infinite);
        }
        protected override void OnStart(string[] args)
        {
            this.CheckServices();
            this.ScheduleService();
        }
        protected override void OnStop()
        {
            this.Schedular.Change(Timeout.Infinite, Timeout.Infinite);
            this.Schedular.Dispose();
        }
        public void CheckServices()
        {
            ...
        }
        public void ScheduleService()
        {
            try
            {
                //Set the Default Time.
                DateTime scheduledTime = DateTime.MinValue;
                if (Properties.Settings.Default.Mode.ToUpper() == "INTERVAL")
                {
                    //Get the Interval in Minutes from AppSettings.
                    int intervalMinutes = Properties.Settings.Default.IntervalMinutes;
                    ...
                }
                ...
                //Change the Timer's Due Time.
                Schedular.Change(dueTime, Timeout.Infinite);
            }
            catch (Exception ex)
            {
                //Stop the Windows Service.
                using (System.ServiceProcess.ServiceController serviceController = new System.ServiceProcess.ServiceController("MyFirstService"))
                {
                    serviceController.Stop();
                }
            }
        }
        private void SchedularCallback(object e)
        {
            //this.WriteToFile("Simple Service Log: {0}");
            this.CheckServices();
            this.ScheduleService();
        }
    }
