    partial class MyService
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Timer _watcherTimer = new System.Timers.Timer();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.ServiceName = "MyService";
            this._watcherTimer.Interval = 6000;
            this._watcherTimer.Enabled = false;
            this._watcherTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.Timer_Tick);
        }
        #endregion
    }
    partial class MyService : ServiceBase
    {
        public MyService()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                logger.Error("Error initializing service",e);
                Stop();
            }
                     
        }
        protected override void OnStart(string[] args)
        {
            _watcherTimer.Enabled = true;
            logger.Info("Service has started at " + DateTime.UtcNow.ToLongDateString());
        }
        protected override void OnStop()
        {
            logger.Info("Service has stopped at " + DateTime.UtcNow.ToLongDateString());
        }
        private void Timer_Tick(object sender, ElapsedEventArgs e)
        {
            logger.Info("Timer Tick");
        }
    }
