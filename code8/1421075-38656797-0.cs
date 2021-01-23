    private void timer1_Tick(object sender, ElapsedEventArgs e)
    {
        Timer timer = sender as Timer;
        timer.Enabled = false;  // stop timer
        try
        {
             //retrieve data from database
             //read rows
    
             //Loop through rows
             //send values through network
             //receive response and update db
         }
         catch (Exception ex)
         {
             Library.WriteErrorLog(ex);
         }
         finally
         {
             timer.Enabled = true;   // start timer again, no overlapping
         }
     }
