         // put   myTimer.Stop() in Restart Method
       private void Tick_Timer_Restart(object sender, RoutedEventArgs e)
        {
            myTimer.Stop();  // stop timmer here and try
            seconds = 0;
            minutes = 0;
            Timertext.Text = "0 minutes : 0 seconds";
            myTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            myTimer.Tick += new EventHandler(Each_Tick);
            myTimer.Start();
    
        }
