    bool alarmTriggered = false;     // <-- new flag
    private void Timer_Tick(object sender, EventArgs e)
    {
        lblTime.Content = DateTime.Now.ToLongTimeString();
    
        if(alarmDate != null)
        {
            int result = DateTime.Compare(DateTime.Now, (DateTime)alarmDate.Value);
    
            lblTest.Content = alarmDate.Value.ToLongTimeString();
            lblTest2.Content = DateTime.Now.ToLongTimeString();
    
            if(result > 0 && !alarmTriggered)   // <-- check flag
            {
                alarmTriggered = true;          // <-- set the flag
                lblWakeUp.Content = "Wake Up!!!!";
                SystemSounds.Beep.Play();
            }
        }
    }   
 
