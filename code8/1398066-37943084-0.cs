    Timer timer = new Timer();
        public void Blinker()
        {            
            timer.Interval = 500;
            timer.Start();
            timer.Tick += new EventHandler(timer_tick);
        }
        void timer_tick(object sender, EventArgs e)
        {
            if(label3.ForeColor = System.Drawing.Color.Green)
            {
                label3.ForeColor = System.Drawing.Color.White;
            }
            
            else
            {
                label3.ForeColor = System.Drawing.Color.Green;
            }            
        }
        public void StopBlinker()
        {
            timer.Stop();
        }
