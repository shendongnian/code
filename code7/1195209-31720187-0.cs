     protected override void OnStart(string[] args)
    {
        timer1 = new Timer();
        this.timer1.Interval = 10800; 
        this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Tick);
        timer1.Enabled = true;
    }
    private void timer1_Tick(object sender, ElapsedEventArgs elapsedEventArg)
    {
       //some code here
    }
    protected override void OnStop()
    {
        timer1.Enabled = false;
      //some code here
    }
