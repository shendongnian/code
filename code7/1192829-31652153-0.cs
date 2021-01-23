    private bool terminating;
    public Service()
    {
        terminating = false;
        timer = new Timer(1000);
        timer.Elapsed += new ElapsedEventHandler(runProcess);
        timer.Enabled = true;
        timer.AutoReset = false;
    }
    
    protected override void OnStart(string[] args)
    {
        timer.Start();
    }
    
    protected override void OnStop()
    {
        terminating = true;
        timer1.Stop();
    }
    
    private void runProcess(object sender, ElapsedEventArgs e)
    {
        // Do stuff
    
        if (!terminating)
            timer.Start(); // Restart timer
    }
