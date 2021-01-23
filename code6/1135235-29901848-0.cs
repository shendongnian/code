        System.Timers.Timer timer = new System.Timers.Timer(2000); 
        timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            MessageBox.Show("testing the timer"); //load your item here
        }
