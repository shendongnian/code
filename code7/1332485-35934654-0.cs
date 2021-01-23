    class Timer : Form {
        var myTimer = new System.Windows.Forms.Timer();
        
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
            // If you want handle interval once call Stop method, if not remove this line
            myTimer.Stop();
    
            // Call waht you want
        }
    
        public void Run() {
            myTimer.Tick += TimerEventProcessor;
    
            // Sets the timer interval to 5 seconds.
            myTimer.Interval = 5000;
            myTimer.Start();
        }
    }
