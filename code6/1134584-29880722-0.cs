        Timer loopTimer = new Timer();
        private void Form1_Load(object sender, EventArgs e)
        {
            loopTimer.Interval = 100;
            loopTimer.Tick += loopTimer_Tick;
            loopTimer.Enabled = true;
        }
        void loopTimer_Tick(object sender, EventArgs e)
        {
            //perform the loop here at the set interval
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //pause/play the loop
            loopTimer.Enabled = !loopTimer.Enabled;
        }
