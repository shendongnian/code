        Timer Timer15 = new Timer();
        Timer Timer30 = new Timer();
        Timer Timer60 = new Timer();
        
        public void SetupTimers()
        {            
            Timer15.Interval = 15 * 60 * 1000;
            Timer30.Interval = 30 * 60 * 1000;
            Timer60.Interval = 60 * 60 * 1000;
            Timer15.Tick += Timer_Tick;
            Timer30.Tick += Timer_Tick;
            Timer60.Tick += Timer_Tick;
            Timer15.Enabled = true;
            Timer30.Enabled = true; 
            Timer60.Enabled = true;
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            // Unsubscribe from the current event. Prevents multuple subscriptions. 
            timer.Tick -= Timer_Tick;   
            // If 60 minutes then reset all timers. 
            if (timer.Interval == 60 * 60 * 1000)
            {
                SetupTimers();
            } 
            //Call sound method here. 
            MakeSound();	        
        }
