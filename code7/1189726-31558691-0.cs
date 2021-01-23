        public int ticks = 0;
        public bool running = false;
        public bool push = false;
        public Form1()
        {
            InitializeComponent();
            timerTest.Tick += new EventHandler(timerTest_Tick);
            timerTest.Interval = 1000;
            timerTest.Start();
        }
        
        private void buttonTest_Click(object sender, EventArgs e)
        {
            push = true;
        }
        private void timerTest_Tick(object sender, EventArgs e)
        {
            ticks++;
            labelTest.Text = ticks.ToString();
            if(running == false)
            {
                running = true;
                backgroundWorkerTest.RunWorkerAsync();
            }
        }
        public void activate()
        {
            ZmienIntervalNaAwaryjny = true;
        }
        public bool ZmienIntervalNaAwaryjny = false;
        private void DoWork(object sender, DoWorkEventArgs e)
        {
           
               if(push == true)
               {
                   activate();
               }
        }
        private void Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if(ZmienIntervalNaAwaryjny == true)
            {
                timerTest.Stop();
                timerTest.Interval = 12000;
                timerTest.Start();
            }
            ZmienIntervalNaAwaryjny = false;
            running = false;
        }
    }
