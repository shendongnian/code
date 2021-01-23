     private BackgroundWorker timer = new BackgroundWorker();
        public void initialize()
        {
            timer.DoWork += doTimer;
            timer.RunWorkerAsync();
        }
        public double milliseconds_Remaining = 0;
        public double milliseconds_Transpired = 0;
        private void doTimer(object sender, DoWorkEventArgs e)
        {
            bool isRunning = true;
            DateTime begin = DateTime.Now;
            while (isRunning)
            {
                //update times
                double milliseconds = DateTime.Now.Subtract(begin).TotalMilliseconds;
                milliseconds_Remaining = 10000 - milliseconds;
                milliseconds_Transpired = milliseconds;
                if (milliseconds >= 10000)
                {
                    //activate timer function
                    //reset 
                    begin = DateTime.Now;
                }
                System.Threading.Thread.Sleep(250);//or 500 or 50 depending on accuracy needed
            }
        }
