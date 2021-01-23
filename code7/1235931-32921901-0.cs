        private const int SAVE_TIME_INTERVAL = 3 * 60 * 1000;
        private bool iWasSavedInTheLastInterval;
        public Form1()
        {
            InitializeComponent();
            //Initialize the timer to your desired waiting interval
            Timer timer = new Timer();
            timer.Interval = SAVE_TIME_INTERVAL;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            //If the timer counts that amount of time we haven't saved in that period of time
            iWasSavedInTheLastInterval = false;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (iWasSavedInTheLastInterval == false)
            {
                MessageBox.Show("Would you like to save any changes before closing?");
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            //If a manual save comes in then we restart the timer and set the flag to true
            iWasSavedInTheLastInterval = true;
            timer1.Stop();
            timer1.Start();
        }
