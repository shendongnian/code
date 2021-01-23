        private void button1_Click_1(object sender, EventArgs e)
        {
                myTimer = new System.Timers.Timer();
                myTimer.Elapsed += new System.Timers.ElapsedEventHandler(rnd);
                myTimer.Interval = 1000;
                myTimer.Start();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            myTimer.Stop();
        }
