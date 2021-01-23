    private void Timer_Tick(object sender, EventArgs e)
    {
        if(timeLeft > 0)
        {
            //Keep track of the time for timer 1, if it isn't 0 subtract it by 1.
            timeLeft = timeLeft - 1;
        }
        else
        {
            //Means timeLeft reached 0, so we have to stop timer1, and activate timer 2.
            timer1.Stop();
            timer2.Enabled = true;
        }
    }
