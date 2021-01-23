    void timer1_Elapsed(object sender, ElapsedEventArgs e)
    {
        timer1.Enabled = false;
        try
        {
            // do stuff
        }
        finally
        {
            timer1.Enabled = true;
        }
    }
