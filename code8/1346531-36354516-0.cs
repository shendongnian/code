    System.Timers.Timer lookAwayTimer = new System.Timers.Timer(10000)
    {
        AutoReset = false
    };
    
    lookAwayTimer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) =>
        {
            MessageBox.Show("Looking is set to yes", "Looking Error", MessageBoxButtons.OK);
            lookAwayTimer.Start();
        };
