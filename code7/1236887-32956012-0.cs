    Timer timer1 = new Timer();
    timer1.Interval = 1; // interval property is in milliseconds. use 1 for 1ms, 1000 for 1 second etc.
    timer1.Tick += timer1_Tick;
    timer1.Enabled = true;
    private void timer1_Tick(object sender, EventArgs e)
    {
        // disable timer to avoid getting triggered while executing method
        timer1.Enabled = false;
    
        // run your method
        writeCSV2(gridIn, outputFil);
    
        // reenable the timer
        timer1.Enabled = true;
    }
