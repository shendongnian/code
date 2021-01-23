    public partial class CERUM_HS : 
    {
        // here is the timer for the automatic closing
        private static System.Timers.Timer aTimer;
        public CERUM_HS()
        {
            InitializeComponent();
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }
        private void Form_Load(object sender, System.EventArgs e)
        {
            // start here the timer when the form is loaded
	        aTimer = new System.Timers.Timer();
            aTimer.Interval = 10;
            aTimer = new System.Timers.Timer(10);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            // Close the Application when this event is fired
            this.Close();
        }
    
    }
