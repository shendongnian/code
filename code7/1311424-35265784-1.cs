        protected override void OnStart(string[] args)
        {
            timer = new Timer();
            timer.Interval = 12000; //Execute the process every 12 seconds
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Tick);
            timer.Enabled = true;
        }
        
        private void timer_Tick(object sender, ElapsedEventArgs e)
        {
            try {
                Runner.WriteErrorLog("Timer ticked and some job has ben called!");
                Runner.Start();
                Runner.WriteErrorLog("Job done!!");
            }
            catch (Exception ex)
            {
                Runner.WriteErrorLog("ERROR!!! " + ex.Message);
            }
        }
