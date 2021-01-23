        Timer timer = new Timer();
        Stopwatch stopwatch = new Stopwatch();
    
        void Method()
        {
            timer.Start();
            stopwatch.Start();
            //...
        }
    
        private void Timer_Tick(object sender, EventArgs e)
        {
            var progress = CalculateProgress (); // calculate progress  
            progressBar.Value = progress; 
            // or
            progressBar.Value =  stopwatch.Elapsed.Seconds;
        }
