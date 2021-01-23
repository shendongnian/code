    public MachinBidule()
    {
        timeIsRunningOut= new System.Timers.Timer();
        timeIsRunningOut.AutoReset = true;
        timeIsRunningOut.Interval = 10;
        timeIsRunningOut.Elapsed += (sender, e) => { UpdateImage(); };
        capture = new Capture();   // Capture the webcam using EmguCV
    }
   
