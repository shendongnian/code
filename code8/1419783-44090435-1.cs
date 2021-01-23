    System.Timers.Timer myTimer = new System.Timers.Timer();
    private void percolateEverySecond()
    {
        myTimer.Elapsed += new ElapsedEventHandler(percolateForTimer);   //this is the function that will be executed every myTimer.Interval
        myTimer.Interval = 1000;
        myTimer.Enabled = true;
    }
    private void percolateForTimer(object source, ElapsedEventArgs e)
    {
        //randomly white site, then union it with surrounding sites
        ...
    }
    private void Start_Click(object sender, EventArgs e)
    {
        ...
        percolateEverySecond();
    }
