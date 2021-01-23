    // Declare the timer
    private static System.Timers.Timer objTimer = new System.Timers.Timer(30000);
    
    // Attach the event handler
    objTimer.Elapsed += OnTimedElapsed;
    
    
    private static void OnTimedElapsed(Object source, System.Timers.ElapsedEventArgs e)
        {
            lstTagsHold.Items.Remove(txtTagID.Text);
        }
