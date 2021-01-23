    Timer tmrExecutor = new Timer();
 
    protected override void OnStart(string[] args)
    {
      tmrExecutor.Elapsed += new ElapsedEventHandler(tmrExecutor_Elapsed); // adding Event
      tmrExecutor.Interval = 3600000; // Set your time here 
      tmrExecutor.Enabled = true;
      tmrExecutor.Start();
    }
 
    private void tmrExecutor_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      //Do your Sending email work here
    }
 
    protected override void OnStop()
    {
      tmrExecutor.Enabled = false;
    }
