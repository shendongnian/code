    private void timer_Tick(object sender, EventArgs e)
    {
        timer.Enabled = false;
        try
        {
            handleTimer();
        }
        finally 
        {
            timer.Enabled = true;
        }
    }
 
